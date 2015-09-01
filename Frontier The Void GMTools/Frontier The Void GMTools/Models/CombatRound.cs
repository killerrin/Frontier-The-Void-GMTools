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
    public class CombatRound : ModelBase
    {
        #region properties
        private bool m_roundLocked = false;
        public bool RoundLocked
        {
            get { return m_roundLocked; }
            set
            {
                if (m_roundLocked == value) return;

                m_roundLocked = value;
                RaisePropertyChanged(nameof(RoundLocked));
            }
        }

        private int m_roundNumber = 0;
        public int RoundNumber
        {
            get { return m_roundNumber; }
            set
            {
                if (m_roundNumber == value) return;

                m_roundNumber = value;
                RaisePropertyChanged(nameof(RoundNumber));
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
                RaisePropertyChanged(nameof(Summary));
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
                RaisePropertyChanged(nameof(CombatForces));
            }
        }
        #endregion

        public CombatRound()
        {
        }

        public CombatForce AddCombatForce(string name)
        {
            CombatForce combatForce = new CombatForce();
            combatForce.Name = name;
            return AddCombatForce(combatForce);
        }

        public CombatForce AddCombatForce(CombatForce combatForce)
        {
            Debug.WriteLine("Adding CombatForce: {0}", combatForce);
            combatForce.Round = this;
            CombatForces.Add(combatForce);
            return combatForce;
        }

        public void RemoveCombatForce(CombatForce combatForce)
        {
            Debug.WriteLine("Removing CombatForce: " + combatForce.ToString());
            CombatForces.Remove(combatForce);
        }

        public void LogToSummary(string message = "", bool addNewLine = true, bool debugString = false)
        {
            Summary += message;
            if (addNewLine) Summary += "[br]";

            if (debugString)
                Debug.WriteLine(message);
        }
    }
}
