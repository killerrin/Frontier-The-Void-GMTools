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
                RaisePropertyChanged(nameof(RoundsOfCombat));
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
                RaisePropertyChanged(nameof(UnitStats));
            }
        }

        public CombatRound FirstRound { get { return RoundsOfCombat[0]; } }
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
                ReloadUnitStats();
            }   

            RoundsOfCombat.Add(round);
        }

        public void ReloadUnitStats()
        {
            UnitStats = new ObservableCollection<Unit>();
            foreach (var unit in App.UnitStatisticsSettings.Units)
            {
                UnitStats.Add(unit);
            }
        }

        public void SimulateCombat(SimulatedCombatMode simulatedCombatMode)
        {
            Debug.WriteLine("Simulating Combat");
            if (LastRound.CombatForces.Count <= 1) return;

            #region Preset Attacks to Skip
            foreach (var forces in LastRound.CombatForces)
            {
                if (forces.Attacking.Count == 0)
                    forces.SkipAttack = false;
            }
            #endregion

            #region Write the Combat Summary if its the first thing we do
            if (RoundsOfCombat.Count == 1)
            {
                if (LastRound.RoundNumber == 0)
                {
                    foreach (var force in LastRound.CombatForces)
                    {
                        LastRound.LogToSummary("[spoiler=" + force.Name + " Attacking With]", false);
                        foreach (var unit in force.Units)
                        {
                            LastRound.LogToSummary(unit.ToString());
                        }

                        LastRound.LogToSummary();
                        LastRound.LogToSummary("Total Units: " + force.TotalUnits);
                        LastRound.LogToSummary("Total Health: " + force.TotalHealth);
                        LastRound.LogToSummary("Total Attack: " + force.TotalAttack);
                        LastRound.LogToSummary("[/spoiler]");
                    }
                }
            }
            #endregion

            CombatRound newRound = new CombatRound();
            newRound.RoundNumber = LastRound.RoundNumber + 1;
            newRound.LogToSummary(string.Format("[spoiler=Round {0}]", newRound.RoundNumber));

            #region Clone the Last Round's CombatForces and add them to our new Round
            List<CombatForce> ClonedCombatForces = new List<CombatForce>();
            foreach (var cF in LastRound.CombatForces)
            {
                CombatForce combatForce = new CombatForce(cF);

                ClonedCombatForces.Add(combatForce);
                newRound.AddCombatForce(combatForce);
            }

            foreach (var clonedForce in ClonedCombatForces)
            {
                foreach (var cF in ClonedCombatForces)
                {
                    // If they are the same, we skip
                    if (clonedForce.Name == cF.Name) continue;

                    // If they are not, we go into the last round and begin cloning its Attacking
                    foreach (var oldForce in LastRound.CombatForces)
                    {
                        // We only want to clone if the Old Forces Name is equal to our cloned force
                        if (oldForce.Name == clonedForce.Name)
                        {
                            // If it is, we get all the Attackings set for the old force
                            foreach (var oldForceAttacking in oldForce.Attacking)
                            {
                                // And if the second loop through matches the attacking name, we add it
                                if (oldForceAttacking.Name == cF.Name)
                                {
                                    clonedForce.Attacking.Add(cF);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region Sort Forces into Easily accessible collections
            Dictionary<CombatForce, List<CombatForce>> attackerDefenderDictionary = new Dictionary<CombatForce, List<CombatForce>>();

            foreach (var defender in ClonedCombatForces)
            {
                List<CombatForce> attackers = new List<CombatForce>();
                foreach (var attacker in ClonedCombatForces)
                {
                    if (defender == attacker) continue;

                    foreach (var n in attacker.Attacking)
                    {
                        if (n.Name == defender.Name)
                            attackers.Add(attacker);
                    }
                }
                attackerDefenderDictionary.Add(defender, attackers);
            }
            #endregion

            Debug.WriteLine("Combat Forces Count {0}", ClonedCombatForces.Count);

            #region Check Electronic Warfare
            foreach (var attacker in ClonedCombatForces)
            {
                if (!attacker.AttemptElectronicWarfare)
                    continue;

                foreach (var defender in ClonedCombatForces)
                {
                    //Debug.WriteLine("Attacker: {0}, Defender {1}", attacker.Name, defender.Name);
                    if (attacker.Attacking.Equals(defender.Name))
                    {
                        Debug.WriteLine("{0} Attempting Hack on {1}", attacker.Name, defender.Name);
                        int hackRoll = Die.Roll(1, 100);
                        double totalEffectedShips = (defender.TotalUnits * hackRoll) / 100;

                        newRound.LogToSummary(string.Format("[spoiler=Hack Roll "+attacker.Name+"]", false));
                        newRound.LogToSummary("Attempting to Hack: " + defender.Name);
                        newRound.LogToSummary(string.Format("Rolled 1d100 : {0}, total {0}", hackRoll));

                        if (hackRoll < 25)
                        {
                            totalEffectedShips = 0.0;
                            newRound.LogToSummary("Failed");
                        }
                        else if (hackRoll < 50)
                        {
                            newRound.LogToSummary("Moderate Success");
                            Debug.WriteLine("Moderate Success, Hack Roll {0}, Total Units Effected {1}, Total Units {2}", hackRoll, totalEffectedShips, defender.TotalUnits);
                        }
                        else if (hackRoll < 75)
                        {
                            newRound.LogToSummary("Success");
                            Debug.WriteLine("Success, Hack Roll {0}, Total Units Effected {1}, Total Units {2}", hackRoll, totalEffectedShips, defender.TotalUnits);
                        }
                        else if (hackRoll <= 100)
                        {
                            newRound.LogToSummary("Great Success");
                            Debug.WriteLine("Great Success, Hack Roll {0}, Total Units Effected {1}, Total Units {2}", hackRoll, totalEffectedShips, defender.TotalUnits);
                        }
                        else
                        {
                            totalEffectedShips = 0.0;
                            newRound.LogToSummary("Failed");
                        }

                        if (totalEffectedShips > 0)
                            newRound.LogToSummary(string.Format("{0} of Ships Effected by Electronic Warfare", totalEffectedShips));

                        newRound.LogToSummary("[br][b]Hack Result[/b]");
                        while (true)
                        {
                            if (totalEffectedShips <= 0.0) break;

                            Unit unit = defender.Units[Die.Roll(1, defender.Units.Count) - 1];
                            if (unit.HackResult == ElectronicWarfareResult.None)
                            {
                                unit.HackResult = (ElectronicWarfareResult)(Die.Roll(1, (int)ElectronicWarfareResult.TakeDamage - 1));
                                totalEffectedShips -= 1.0;

                                newRound.LogToSummary(string.Format("{0} Was Hacked. Result is {1}", unit.Name, StringHelpers.AddSpacesToSentence(unit.HackResult.ToString(), true)));
                            }

                            // To keep from an infinite loop, double check there is no more left to set
                            bool escapeCheck = false;
                            foreach (var u in defender.Units)
                            {
                                if (u.HackResult == ElectronicWarfareResult.None) { escapeCheck = true; break; }
                            }
                            if (!escapeCheck) break;
                        }

                        newRound.LogToSummary("[/spoiler]", false);
                        break;
                    }
                }
            }
            #endregion

            #region Calculate Raw Damage
            Debug.WriteLine("Calculating Raw Damage");
            foreach (var attacker in ClonedCombatForces)
            {
                if (attacker.SkipAttack) continue;

                List<CombatForce> defenderList = attackerDefenderDictionary[attacker];
                if (defenderList.Count > 0)
                {
                    newRound.LogToSummary("[spoiler=Attack Roll " + attacker.Name + "]", false);

                    List<Unit> combinedDefenderUnits = new List<Unit>();
                    foreach (var defender in defenderList)
                    {
                        newRound.LogToSummary("Target: " + defender.Name);

                        if (defender.IsInvulnerable)
                            newRound.LogToSummary(defender.Name + " Is Invulnerable");

                        foreach (var unit in defender.Units)
                        {
                            combinedDefenderUnits.Add(unit);
                        }
                    }

                    // Damage Tracker
                    int damageDealt = 0;

                    // Raw Damage
                    int damageRoll = Die.Roll(1, (int)attacker.TotalAttack);
                    if ((int)attacker.TotalAttack == 0)
                        damageRoll = 0;

                    damageDealt += damageRoll;
                    newRound.LogToSummary(string.Format("Rolled 1d{0} : {1}, total {1}", (int)attacker.TotalAttack, damageRoll));

                    // Apply Admiral Command Scores
                    damageDealt += attacker.AdmiralScore;
                    newRound.LogToSummary(string.Format("+{0} Admiral/Command Score ({1})", attacker.AdmiralScore, attacker.Name));

                    // Combine Units and check Negations
                    int totalFighterNegations = 0;
                    foreach (var unit in combinedDefenderUnits)
                    {
                        #region Take off 1d4 of damage for each Area Defence Destroyer
                        if (unit.Name == "Area Defence Destroyer")
                        {
                            Debug.WriteLine("Activating Area Defence Destroyers");

                            int damageNegated = 0;
                            damageNegated = Die.Roll(1, 5);
                            damageDealt -= damageNegated;
                            newRound.LogToSummary(string.Format("-{0} Area Defence Destroyer ({1}) : Rolled 1d5 : {0}, total {0}", damageNegated, unit.CombatForce.Name), true, true);
                        }
                        #endregion

                        #region Take Damage if Electronic Warfare
                        if (unit.HackResult == ElectronicWarfareResult.TakeDamage)
                        {
                            int hackDamage = Die.Roll(1, (int)unit.Health);
                            unit.Health -= hackDamage;
                            newRound.LogToSummary(string.Format("+{1} Hack Damage: {0} took {1} points of Damage: Rolled 1d{2} : {1}, total {1}", unit.Name, hackDamage, (int)unit.Health));
                        }
                        #endregion

                        #region Total up Fighter Squadron Negations
                        if (unit.Name == "Fighter Squadron")
                        {
                            totalFighterNegations += (int)unit.Health;
                        }
                        #endregion
                    }

                    if (totalFighterNegations > 0)
                    {
                        Debug.WriteLine("Negating Fighter Damage");
                        newRound.LogToSummary("[br][b]Fighter Result[/b]");

                        foreach (var attackingUnit in attacker.Units)
                        {
                            if (totalFighterNegations <= 0) break;

                            if (attackingUnit.Name == "Fighter Squadron")
                            {
                                newRound.LogToSummary(string.Format("Fighter Squadron ({0} Units, {1}) was negated by Defenders Fighter Squadron ({2} Units)", (int)attackingUnit.Health, attackingUnit.CombatForce.Name, totalFighterNegations));
                                totalFighterNegations -= (int)attackingUnit.Health;
                            }
                            else if (attackingUnit.Name == "Strike Fighter Squadron")
                            {
                                int damageNegated = 0;
                                for (int i = (int)attackingUnit.Health; i > 0; i--)
                                {
                                    if (totalFighterNegations <= 0) break;
                                    damageNegated++;
                                    totalFighterNegations--;
                                }

                                newRound.LogToSummary(string.Format("Strike Fighter Squadron ({0} Units, {1}) was negated by Defenders Fighter Squadron ({2} Units) for {3} points of Damage", (int)attackingUnit.Health, attackingUnit.CombatForce.Name, totalFighterNegations, damageNegated));
                                damageDealt -= damageNegated;
                            }
                        }
                    }

                    newRound.LogToSummary("[br][b]Result[/b]");
                    int tempDamageDealt = damageDealt;
                    while (tempDamageDealt > 0 )
                    {
                        CombatForce force = defenderList[Die.Roll(1, defenderList.Count) - 1];
                        force.DamageDealt += 1.0;
                        tempDamageDealt -= 1;
                    }
                    foreach (var force in defenderList)
                    {
                        double damageSummaryInput = 0;
                        if (defenderList.Count > 1)
                            damageSummaryInput = force.DamageDealt;
                        else damageSummaryInput = damageDealt;

                        newRound.LogToSummary(string.Format("{0}, Total Damage Dealt: {1}", force.Name, damageSummaryInput), true, true);
                    }
                    newRound.LogToSummary("[/spoiler]", false);
                }
            }
            #endregion

            #region Apply Damage
            Debug.WriteLine("Applying Damage");
            foreach (var force in ClonedCombatForces)
            {
                newRound.LogToSummary("[spoiler=Combat Result " + force.Name+"]", false);
                newRound.LogToSummary(string.Format("Total Damage Dealt: {0}", force.DamageDealt));
                while (force.DamageDealt > 0)
                {
                    if (force.Units.Count <= 0) break;

                    if (simulatedCombatMode == SimulatedCombatMode.RandomizedTargets)
                    {
                        double pointsOfDamage = 1.0;
                        Unit unit = force.Units[Die.Roll(1, force.Units.Count) - 1];

                        if (unit.Invulnerable)
                        {
                            newRound.LogToSummary(string.Format("{0} is Invulnerable and shook off {1} points of Damage", unit.Name, pointsOfDamage));
                        }
                        else
                        {
                            unit.Health -= 1.0;
                            if (unit.Health <= 0)
                            {
                                force.RemoveUnit(unit);
                                force.DestroyedUnits.Add(unit);
                                newRound.LogToSummary(string.Format("[red]{0} took {1} points of Damage and was Destroyed[/red]", unit.Name, pointsOfDamage));
                            }
                            else
                            {
                                newRound.LogToSummary(string.Format("[green]{0} took {1} points of Damage and has {2} HP Left[/green]", unit.Name, pointsOfDamage, unit.Health));
                            }
                        }
                        force.DamageDealt -= pointsOfDamage;
                    }
                }

                newRound.LogToSummary("[br][b]Remaining Units[/b]");
                foreach (var unit in force.Units)
                {
                    unit.HackResult = ElectronicWarfareResult.None;
                    newRound.LogToSummary(unit.ToString());
                }

                newRound.LogToSummary();
                newRound.LogToSummary("Total Units: " + force.TotalUnits);
                newRound.LogToSummary("Total Health: " + force.TotalHealth);
                newRound.LogToSummary("Total Attack: " + force.TotalAttack);
                newRound.LogToSummary("[/spoiler]", false);
            }
            #endregion

            #region Calculate Recoverable Forces
            foreach (var force in ClonedCombatForces)
            {
                if (force.Units.Count == 0)
                {
                    int recoverablePercentageRoll = Die.Roll(1, 100);
                    double recoverableUnitAmount = (force.DestroyedUnits.Count * recoverablePercentageRoll) / 100;

                    newRound.LogToSummary("[spoiler=Units Recoverable " + force.Name + "]", false);
                    newRound.LogToSummary(string.Format("Rolled 1d100 : {0}, total {0}", recoverablePercentageRoll));
                    newRound.LogToSummary(string.Format("{0}% of Units ({1} Units) are Recoverable", recoverablePercentageRoll, recoverableUnitAmount));

                    List<Unit> tempRecoverableUnits = new List<Unit>();
                    while (true)
                    {
                        if (recoverableUnitAmount < 1.0) break;
                        if (force.DestroyedUnits.Count <= 0) break;

                        Unit unit = force.DestroyedUnits[Die.Roll(1, force.DestroyedUnits.Count) - 1];
                        tempRecoverableUnits.Add(unit);
                        force.DestroyedUnits.Remove(unit);
                        recoverableUnitAmount -= 1.0;
                    }

                    newRound.LogToSummary("[hr][b]Recoverable Units[/b]");
                    foreach (var unit in tempRecoverableUnits)
                    {
                        newRound.LogToSummary(string.Format("{0}", unit.ToString()));
                        force.DestroyedUnits.Add(unit);
                    }

                    tempRecoverableUnits.Clear();
                    newRound.LogToSummary("[/spoiler]", false);
                }
            }
            #endregion

            // Reset Values on the Forces
            foreach (var force in newRound.CombatForces)
            {
                force.DamageDealt = 0.0;
                force.IsInvulnerable = false;
                force.AttemptElectronicWarfare = false;
                force.SkipAttack = false;
            }

            // Lastly, Lock the Last Round, finish the Summary then add the new Round
            LastRound.RoundLocked = true;
            newRound.LogToSummary(string.Format("[/spoiler]"));
            RoundsOfCombat.Add(newRound);
        }

        public void ClearSimulation()
        {
            RoundsOfCombat = new ObservableCollection<CombatRound>();
            RoundsOfCombat.Add(new CombatRound());
        }

        public void RemoveRound(CombatRound round)
        {
            RoundsOfCombat.Remove(round);
            if (RoundsOfCombat.Count == 0) { ClearSimulation(); return; }

            LastRound.RoundLocked = false;
            if (LastRound.RoundNumber == 0)
                LastRound.Summary = "";
        }

        public void AddCombatForce(string name)
        {
            foreach (var force in LastRound.CombatForces)
            {
                if (force.Name == name) return;
            }

            LastRound.AddCombatForce(name);
        }

        public void RemoveCombatForce(CombatForce combatForce)
        {
            LastRound.RemoveCombatForce(combatForce);
        }
    }
}