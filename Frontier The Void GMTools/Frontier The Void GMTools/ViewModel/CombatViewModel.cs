using Frontier_The_Void_GMTools.DnDTools;
using Frontier_The_Void_GMTools.Models;
using Frontier_The_Void_GMTools.Models.EnumTypes;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System;

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

        /// <summary>
        /// Initializes a new instance of the RollDiceViewModel class.
        /// </summary>
        /// 
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
                        Unit unit = new Unit(combatForce);
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
            }   

            RoundsOfCombat.Add(round);
        }

        public void AddCombatForce(string text)
        {
            RoundsOfCombat[RoundsOfCombat.Count - 1].AddCombatForce(text);
        }

        public void RemoveCombatForce(CombatForce combatForce)
        {
            RoundsOfCombat[RoundsOfCombat.Count - 1].RemoveCombatForce(combatForce);
        }

        public void SimulateCombat()
        {
            Debug.WriteLine("Simulating Combat");
        }
    }
}