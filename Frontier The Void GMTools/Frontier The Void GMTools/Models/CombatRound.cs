using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier_The_Void_GMTools.Models
{
    public class CombatRound : INotifyPropertyChanged
    {
        public const string RoundLockedPropertyName = "RoundLocked";
        public const string SummaryPropertyName = "Summary";
        public const string CombatForcesPropertyName = "CombatForces";
        public const string CombatForceNamesPropertyName = "CombatForceNames";

        #region properties
        private bool m_roundLocked = false;
        public bool RoundLocked
        {
            get { return m_roundLocked; }
            set
            {
                if (m_roundLocked == value) return;

                m_roundLocked = value;
                RaisePropertyChanged(RoundLockedPropertyName);
            }
        }

        private string m_summary = "";
        public string Summary
        {
            get { return m_summary; }
            set
            {
                if (m_summary == value) return;

                m_summary = value;
                RaisePropertyChanged(SummaryPropertyName);
            }
        }

        private ObservableCollection<CombatForce> m_combatForces = new ObservableCollection<CombatForce>();
        public ObservableCollection<CombatForce> CombatForces
        {
            get { return m_combatForces; }
            set
            {
                if (m_combatForces == value) return;

                m_combatForces = value;
                RaisePropertyChanged(CombatForcesPropertyName);
            }
        }

        private ObservableCollection<string> m_combatForceNames = new ObservableCollection<string>();
        public ObservableCollection<string> CombatForceNames
        {
            get { return m_combatForceNames; }
            set
            {
                if (m_combatForceNames == value) return;

                m_combatForceNames = value;
                RaisePropertyChanged(CombatForceNamesPropertyName);
            }
        }
        #endregion

        public CombatRound()
        {
        }

        public CombatForce AddCombatForce(string name)
        {
            Debug.WriteLine("Adding CombatForce: {0}", name);
            CombatForce combatForce = new CombatForce();
            combatForce.Round = this;
            combatForce.Name = name;
            CombatForces.Add(combatForce);

            RecompileNames();
            return combatForce;
        }

        public void RemoveCombatForce(CombatForce combatForce)
        {
            Debug.WriteLine("Removing CombatForce: " + combatForce.ToString());
            CombatForces.Remove(combatForce);
            RecompileNames();
        }

        private void RecompileNames()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            names.Add("");
            for (int i = 0; i < CombatForces.Count; i++)
                names.Add(CombatForces[i].Name);
            CombatForceNames = names;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
