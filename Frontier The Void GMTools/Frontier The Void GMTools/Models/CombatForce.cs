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

        public const string AdmiralScorePropertyName = "AdmiralScore";
        public const string AttemptElectronicWarfarePropertyName = "AttemptElectronicWarfare";

        public const string AttackingPropertyName = "Attacking";
        public const string IsDefendingPropertyName = "IsDefending";
        public const string IsInvulnerablePropertyName = "IsInvulnerable";
        public const string SkipAttackPropertyName = "SkipAttack";
        public const string UnitsPropertyName = "Units";

        public const string TotalUnitsPropertyName =  "TotalUnits";
        public const string TotalHealthPropertyName = "TotalHealth";
        public const string TotalAttackPropertyName = "TotalAttack";

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

        private int _admiralScore = 0;
        public int AdmiralScore
        {
            get { return _admiralScore; }
            set
            {
                if (_admiralScore == value) return;

                //Debug.WriteLine("AdmiralScore Changed to {0}", value);
                _admiralScore = value;
                RaisePropertyChanged(AdmiralScorePropertyName);
            }
        }

        private bool _attemptElectronicWarfare = false;
        public bool AttemptElectronicWarfare
        {
            get { return _attemptElectronicWarfare; }
            set
            {
                if (_attemptElectronicWarfare == value) return;

                //Debug.WriteLine("AttemptHack Changed to {0}", value);
                _attemptElectronicWarfare = value;
                RaisePropertyChanged(AttemptElectronicWarfarePropertyName);
            }
        }

        private string _attacking = "";
        public string Attacking
        {
            get { return _attacking; }
            set
            {
                if (_attacking == value) return;

                //Debug.WriteLine("Attacking Changed To " + value);
                _attacking = value;
                RaisePropertyChanged(NamePropertyName);
            }
        }

        private bool _isDefending = false;
        public bool IsDefending
        {
            get { return _isDefending; }
            set
            {
                if (_isDefending == value) return;

                //Debug.WriteLine("IsDefending Changed to {0}", value);
                _isDefending = value;
                RaisePropertyChanged(IsDefendingPropertyName);
            }
        }

        private bool _isInvulnerable = false;
        public bool IsInvulnerable
        {
            get { return _isInvulnerable; }
            set
            {
                if (_isInvulnerable == value) return;

                //Debug.WriteLine("IsInvulnerable Changed to {0}", value);
                _isInvulnerable = value;
                RaisePropertyChanged(IsInvulnerablePropertyName);
            }
        }

        private bool _skipAttack = false;
        public bool SkipAttack
        {
            get { return _skipAttack; }
            set
            {
                if (_skipAttack == value) return;

                //Debug.WriteLine("SkipAttack Changed to {0}", value);
                _skipAttack = value;
                RaisePropertyChanged(SkipAttackPropertyName);
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
        public double DamageDealt = 0.0;
        public bool ElectronicWarfareSuccessful = false;

        public int TotalUnits { get { return Units.Count; } }
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
                {
                    attack += Units[i].AttackPower;
                    if (Units[i].IsCommandAndControl)
                        attack += 2;
                }

                return attack;
            }
        }

        public void RaiseHPAPQuantityChanged()
        {
            RaisePropertyChanged(TotalUnitsPropertyName);
            RaisePropertyChanged(TotalHealthPropertyName);
            RaisePropertyChanged(TotalAttackPropertyName);
        }
        #endregion

        public CombatForce()
        {
        }
        public CombatForce(CombatForce otherForce)
        {
            Name = otherForce.Name;

            AdmiralScore = otherForce.AdmiralScore;
            AttemptElectronicWarfare = otherForce.ElectronicWarfareSuccessful;

            Attacking = otherForce.Attacking;
            IsDefending = otherForce.IsDefending;
            IsInvulnerable = otherForce.IsInvulnerable;
            SkipAttack = otherForce.SkipAttack;

            Round = otherForce.Round;

            foreach (var unit in otherForce.Units)
            {
                AddUnit(new Unit(unit));
            }
        }

        public void AddUnit(Unit unit)
        {
            Debug.WriteLine("Adding Unit {0} to {1}", unit.ToString(), Name);
            unit.CombatForce = this;
            Units.Add(unit);
            RaiseHPAPQuantityChanged();
        }

        public void RemoveUnit(Unit unit)
        {
            Debug.WriteLine("Removing Unit {0} from {1}", unit.ToString(), Name);
            Units.Remove(unit);
            RaiseHPAPQuantityChanged();
        }

        public void RemoveAllUnits()
        {
            Debug.WriteLine("Removing All Units from " + Name);
            Units.Clear();
            RaiseHPAPQuantityChanged();
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
