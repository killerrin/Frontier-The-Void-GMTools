using Frontier_The_Void_GMTools.Models.EnumTypes;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier_The_Void_GMTools.Models
{
    public class Unit : INotifyPropertyChanged
    {
        public const string TypeOfUnitPropertyName = "TypeOfUnit";
        public const string NamePropertyName = "Name";
        public const string HealthPropertyName = "Health";
        public const string AttackPowerPropertyName = "AttackPower";

        public const string CostPropertyName = "Cost";
        public const string BuildRatePropertyName = "BuildRate";
        public const string NumberBuildAtATimePropertyName = "NumberBuildAtATime";

        #region Properties
        private UnitType _typeOfUnit = UnitType.Both;
        public UnitType TypeOfUnit
        {
            get { return _typeOfUnit; }
            set
            {
                if (_typeOfUnit == value) return;

                _typeOfUnit = value;
                RaisePropertyChanged(TypeOfUnitPropertyName);
            }
        }

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

        private double _health = 0.0;
        public double Health
        {
            get { return _health; }
            set
            {
                if (_health == value) return;

                _health = value;
                RaisePropertyChanged(HealthPropertyName);
            }
        }

        private double _attackPower = 0.0;
        public double AttackPower
        {
            get { return _attackPower; }
            set
            {
                if (_attackPower == value) return;

                _attackPower = value;
                RaisePropertyChanged(AttackPowerPropertyName);
            }
        }

        private int _cost = 0;
        public int Cost
        {
            get { return _cost; }
            set
            {
                if (_cost == value) return;

                _cost = value;
                RaisePropertyChanged(CostPropertyName);
            }
        }

        private int _buildRate = 0;
        public int BuildRate
        {
            get { return _buildRate; }
            set
            {
                if (_buildRate == value) return;

                _buildRate = value;
                RaisePropertyChanged(BuildRatePropertyName);
            }
        }

        private int _numberBuildAtATime = 0;
        public int NumberBuildAtATime
        {
            get { return _numberBuildAtATime; }
            set
            {
                if (_numberBuildAtATime == value) return;

                _numberBuildAtATime = value;
                RaisePropertyChanged(NumberBuildAtATimePropertyName);
            }
        }
        #endregion

        #region Helper Properties
        public bool HasAttack { get { return AttackPower != 0.0; } }
        public CombatForce Owner { get; set; }
        #endregion

        public Unit()
        {
        }

        public Unit(UnitType typeOfUnit, string name, double health, double attackPower, int cost, int buildRate, int numberBuildAtATime)
        {
            TypeOfUnit = typeOfUnit;
            Name = name;
            Health = health;
            AttackPower = attackPower;

            Cost = cost;
            BuildRate = buildRate;
            NumberBuildAtATime = numberBuildAtATime;
        }

        public Unit(Unit otherUnit)
        {
            TypeOfUnit = otherUnit.TypeOfUnit;
            Name = otherUnit.Name;
            Health = otherUnit.Health;
            AttackPower = otherUnit.AttackPower;

            Cost = otherUnit.Cost;
            BuildRate = otherUnit.BuildRate;
            NumberBuildAtATime = otherUnit.NumberBuildAtATime;

            Owner = otherUnit.Owner;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
            return string.Format("{0}, UnitType: {1}, Health: {2}, Attack: {3}", Name, TypeOfUnit.ToString(), Health, AttackPower);
        }
    }
}
