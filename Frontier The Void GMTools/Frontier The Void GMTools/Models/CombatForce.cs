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
    public class CombatForce : INotifyPropertyChanged
    {
        #region Properties
        public const string NamePropertyName = "Name";
        public const string AttackingPropertyName = "Attacking";
        public const string UnitsPropertyName = "Units";

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;

                _name = value;
                RaisePropertyChanged(NamePropertyName);
            }
        }

        private string _attacking = "";
        public string Attacking
        {
            get { return _attacking; }
            set
            {
                if (_attacking == value) return;

                _attacking = value;
                RaisePropertyChanged(NamePropertyName);
            }
        }

        private ObservableCollection<Unit> _units = new ObservableCollection<Unit>();
        public ObservableCollection<Unit> Units
        {
            get { return _units; }
            set
            {
                if (_units == value) return;

                _units = value;
                RaisePropertyChanged(UnitsPropertyName);
            }
        }

        public CombatRound Round { get; set; }
        #endregion

        #region Helper Properties
        public double TotalHealth
        {
            get
            {
                double health = 0.0;
                for (int i = 0; i < Units.Count; i++)
                    health += Units[i].Health;

                return health;
            }
        }
        public double TotalAttack
        {
            get
            {
                double attack = 0.0;
                for (int i = 0; i < Units.Count; i++)
                    attack += Units[i].AttackPower;

                return attack;
            }
        }
        #endregion

        public CombatForce()
        {
        }
        public CombatForce(CombatForce otherForce)
        {
            Name = otherForce.Name;
            Attacking = otherForce.Name;

            foreach (var unit in otherForce.Units)
            {
                Unit u = new Unit(this);
                u.Name = unit.Name;
                u.TypeOfUnit = unit.TypeOfUnit;
                u.Health = unit.Health;
                u.AttackPower = unit.AttackPower;
            }
        }

        public void AddUnit(Unit unit)
        {
            Debug.WriteLine("Adding Unit {0} to {1}", unit.ToString(), Name);
            Units.Add(unit);
        }

        public void RemoveUnit(Unit unit)
        {
            Debug.WriteLine("Removing Unit {0} from {1}", unit.ToString(), Name);
            Units.Remove(unit);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
            return string.Format("{0}, Attacking: {2}, Number of Units: {1}, HP: {3}, AP: {4}", Name, Units.Count, Attacking, TotalHealth, TotalAttack);
        }
    }
}
