using Frontier_The_Void_GMTools.Models.EnumTypes;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier_The_Void_GMTools.Models
{
    public class Unit : INotifyPropertyChanged
    {
        #region Properties
        private UnitType _typeOfUnit = UnitType.Both;
        public UnitType TypeOfUnit
        {
            get { return _typeOfUnit; }
            set
            {
                if (_typeOfUnit == value) return;

                _typeOfUnit = value;
                RaisePropertyChanged(nameof(TypeOfUnit));
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
                RaisePropertyChanged(nameof(Name));
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
                RaisePropertyChanged(nameof(Health));
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
                RaisePropertyChanged(nameof(AttackPower));
            }
        }

        private bool _isCommandAndControl = false;
        public bool IsCommandAndControl
        {
            get { return _isCommandAndControl; }
            set
            {
                if (_isCommandAndControl == value) return;

                Debug.WriteLine("IsCommandAndControl Changed to {0}", value);
                _isCommandAndControl = value;

                RaisePropertyChanged(nameof(IsCommandAndControl));
                if (CombatForce != null) CombatForce.RaiseHPAPQuantityChanged();
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
                RaisePropertyChanged(nameof(Cost));
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
                RaisePropertyChanged(nameof(BuildRate));
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
                RaisePropertyChanged(nameof(NumberBuildAtATime));
            }
        }
        #endregion

        #region Helper Properties
        public ElectronicWarfareResult HackResult = ElectronicWarfareResult.None;
        public bool HasAttack { get { return AttackPower != 0.0; } }
        public CombatForce CombatForce { get; set; }
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

            IsCommandAndControl = otherUnit.IsCommandAndControl;

            Cost = otherUnit.Cost;
            BuildRate = otherUnit.BuildRate;
            NumberBuildAtATime = otherUnit.NumberBuildAtATime;

            CombatForce = otherUnit.CombatForce;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
            string nameOverride = "";
            if (IsCommandAndControl)
                nameOverride += "C&C ";
            nameOverride += Name;
            
            return string.Format("{0}: Health: {1}, Attack: {2}", nameOverride, Health, AttackPower);
        }
    }
}
