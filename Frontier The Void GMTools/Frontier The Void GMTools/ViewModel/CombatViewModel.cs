using Frontier_The_Void_GMTools.DnDTools;
using Frontier_The_Void_GMTools.Models;
using Frontier_The_Void_GMTools.Models.EnumTypes;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System;
using System.Collections.Generic;

namespace Frontier_The_Void_GMTools.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CombatViewModel : ViewModelBase
    {
        public const string RoundsOfCombatPropertyName = "RoundsOfCombat";
        public const string UnitStatsPropertyName = "UnitStats";

        Dice Die = new Dice();

        private ObservableCollection<CombatRound> m_roundsOfCombat = new ObservableCollection<CombatRound>();
        public ObservableCollection<CombatRound> RoundsOfCombat
        {
            get { return m_roundsOfCombat; }
            set
            {
                if (m_roundsOfCombat == value)
                    return;

                m_roundsOfCombat = value;
                RaisePropertyChanged(RoundsOfCombatPropertyName);
            }
        }

        private ObservableCollection<Unit> m_unitStats = new ObservableCollection<Unit>();
        public ObservableCollection<Unit> UnitStats
        {
            get { return m_unitStats; }
            set
            {
                if (m_unitStats == value)
                    return;

                m_unitStats = value;
                RaisePropertyChanged(UnitStatsPropertyName);
            }
        }

        public CombatRound LastRound { get { return RoundsOfCombat[RoundsOfCombat.Count - 1]; } }
        
        /// <summary>
        /// Initializes a new instance of the RollDiceViewModel class.
        /// </summary>
        public CombatViewModel()
        {
            CombatRound round = new CombatRound();

            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
                for (int i = 0; i < 2; i++)
                {
                    CombatForce combatForce = round.AddCombatForce("Combat Force " + i);

                    for (int x = 0; x < 2; x++)
                    {
                        Unit unit = new Unit();
                        unit.CombatForce = combatForce;
                        unit.Name = "Unit " + x;
                        unit.TypeOfUnit = UnitType.Both;
                        unit.Health = 6.0;
                        unit.AttackPower = 6.0;
                        combatForce.AddUnit(unit);
                    }
                }
            }
            else
            {
                // Code runs "for real"
                foreach (var unit in App.UnitStatisticsSettings.Units)
                {
                    UnitStats.Add(unit);
                }
            }   

            RoundsOfCombat.Add(round);
        }

        public void SimulateCombat(SimulatedCombatMode simulatedCombatMode)
        {
            Debug.WriteLine("Simulating Combat");
            if (LastRound.CombatForces.Count <= 1) return;
            foreach (var item in LastRound.CombatForces)
            {
                if (string.IsNullOrWhiteSpace(item.Attacking))
                    return;
            }

            CombatRound newRound = new CombatRound();
            newRound.RoundNumber = LastRound.RoundNumber + 1;

            // First we need to clone the Last Round's CombatForces
            List<CombatForce> ClonedCombatForces = new List<CombatForce>();
            foreach (var cF in LastRound.CombatForces)
            {
                CombatForce combatForce = new CombatForce(cF);
                ClonedCombatForces.Add(combatForce);
            }

            Debug.WriteLine("Combat Forces Count {0}", ClonedCombatForces.Count);

            #region Calculate Raw Damage
            Debug.WriteLine("Calculating Raw Damage");
            foreach (var attacker in ClonedCombatForces)
            {
                foreach (var defender in ClonedCombatForces)
                {
                    //Debug.WriteLine("Attacker: {0}, Defender {1}", attacker.Name, defender.Name);
                    if (attacker.Attacking.Equals(defender.Name))
                    {
                        int damageDealt = 0;
                        damageDealt += Die.Roll(1, (int)attacker.TotalAttack);
                        damageDealt += attacker.AdmiralScore;
                        defender.DamageDealt = damageDealt;

                        Debug.WriteLine("{0} took {1} Raw Damage", defender.Name, defender.DamageDealt);
                        break;
                    }
                }
            }
            #endregion

            #region Take off 1d4 of damage for each Area Defence Destroyer
            Debug.WriteLine("Activating Area Defence Destroyers");
            foreach (var force in ClonedCombatForces)
            {
                foreach (var unit in force.Units)
                {
                    if (unit.Name == "Area Defence Destroyer")
                    {
                        int damageNegated = 0;
                        damageNegated -= Die.Roll(1, 5);
                        force.DamageDealt -= damageNegated;

                        Debug.WriteLine("{0} Area Defence Destroyers Negated {1} Points of Damage", force.Name, damageNegated);
                    }
                }
            }
            #endregion

            #region Negate Fighter Damage
            Debug.WriteLine("Negating Fighter Damage");
            foreach (var attacker in ClonedCombatForces)
            {
                int totalNegations = 0;
                foreach (var unit in attacker.Units)
                {
                    if (unit.Name == "Fighter Squadron")
                    {
                        totalNegations += (int)unit.Health;
                        Debug.WriteLine("{0} Fighter Squadrons can Negate {1} points of Fighter Squadron Damage");
                    }
                }

                if (totalNegations > 0)
                {
                    foreach (var defender in ClonedCombatForces)
                    {
                        if (attacker.Attacking.Equals(defender.Name))
                        {
                            foreach (var defenderUnit in defender.Units)
                            {
                                if (totalNegations <= 0) break;

                                if (defenderUnit.Name == "Fighter Squadron")
                                {
                                    totalNegations--;
                                }
                                else if (defenderUnit.Name == "Strike Fighter Squadron")
                                {
                                    attacker.DamageDealt -= 1;
                                    totalNegations--;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Apply Damage
            Debug.WriteLine("Applying Damage");
            foreach (var force in ClonedCombatForces)
            {
                while (force.DamageDealt > 0)
                {
                    if (simulatedCombatMode == SimulatedCombatMode.RandomizedTargets)
                    {
                        Unit unit = force.Units[Die.Roll(1, force.Units.Count) - 1];
                        unit.Health -= 1.0;
                        if (unit.Health <= 0)
                            force.RemoveUnit(unit);

                        force.DamageDealt--;
                    }

                    if (force.Units.Count <= 0) break;
                }
            }
            #endregion

            // Finally, Add the Attackers and Defenders to the Combat Round
            foreach (var aCF in ClonedCombatForces) { newRound.AddCombatForce(aCF); }

            // Lastly, Lock the Last Round then add the new Round
            LastRound.RoundLocked = true;
            RoundsOfCombat.Add(newRound);
        }

        public void ClearSimulation()
        {
            RoundsOfCombat = new ObservableCollection<CombatRound>();
            RoundsOfCombat.Add(new CombatRound());
        }

        public void AddCombatForce(string text)
        {
            LastRound.AddCombatForce(text);
        }

        public void RemoveCombatForce(CombatForce combatForce)
        {
            LastRound.RemoveCombatForce(combatForce);
        }
    }
}