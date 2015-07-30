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

        Dice dice = new Dice();

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
            round.RoundNumber = 0;

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
                        combatForce.Units.Add(unit);
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

        public void SimulateCombat()
        {
            Debug.WriteLine("Simulating Combat");

            CombatRound newRound = new CombatRound();
            newRound.RoundNumber = LastRound.RoundNumber + 1;

            // First we need to split up all of the Forces between Attacker and Defender
            List<CombatForce> Attacking = new List<CombatForce>();
            List<CombatForce> Defending = new List<CombatForce>();
            foreach (var cF in LastRound.CombatForces)
            {
                CombatForce combatForce = new CombatForce(cF);
                if (combatForce.IsDefending) { Defending.Add(combatForce); }
                else { Attacking.Add(combatForce); }
            }

            if (Attacking.Count <= 0 || Defending.Count <= 0) return;


            // Finally, Add the Attackers and Defenders to the Combat Round
            foreach (var aCF in Attacking) { newRound.AddCombatForce(aCF); }
            foreach (var dCF in Defending) { newRound.AddCombatForce(dCF); }

            // Lastly, Lock the Last Round then add the new Round
            LastRound.RoundLocked = true;
            RoundsOfCombat.Add(newRound);
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