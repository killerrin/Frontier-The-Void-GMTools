using Frontier_The_Void_GMTools.Models.EnumTypes;
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
    public class CombatForce : ModelBase
    {
        #region Properties
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

        private int _crewScore = 0;
        public int CrewScore
        {
            get { return _crewScore; }
            set
            {
                if (_crewScore == value) return;

                //Debug.WriteLine("AdmiralScore Changed to {0}", value);
                _crewScore = value;
                RaisePropertyChanged(nameof(CrewScore));
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
                RaisePropertyChanged(nameof(AttemptElectronicWarfare));
            }
        }

        private bool _hasAdvancedScanners = false;
        public bool HasAdvancedScanners
        {
            get { return _hasAdvancedScanners; }
            set
            {
                if (_hasAdvancedScanners == value) return;
                
                _hasAdvancedScanners = value;
                RaisePropertyChanged(nameof(HasAdvancedScanners));
            }
        }

        private ObservableCollection<CombatForce> _attacking = new ObservableCollection<CombatForce>();
        public ObservableCollection<CombatForce> Attacking
        {
            get { return _attacking; }
            set
            {
                if (_attacking == value) return;

                //Debug.WriteLine("Attacking Changed To " + value);
                _attacking = value;
                RaisePropertyChanged(nameof(Attacking));
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
                RaisePropertyChanged(nameof(IsInvulnerable));
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
                RaisePropertyChanged(nameof(SkipAttack));
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
                RaisePropertyChanged(nameof(Units));
            }
        }

        private ObservableCollection<Unit> _destroyedUnits = new ObservableCollection<Unit>();
        public ObservableCollection<Unit> DestroyedUnits
        {
            get { return _destroyedUnits; }
            set
            {
                if (_destroyedUnits == value) return;

                _destroyedUnits = value;
                RaisePropertyChanged(nameof(DestroyedUnits));
            }
        }

        public CombatRound Round { get; set; }
        #endregion

        #region Helper Properties
        public CombatForce UI_ATTACKING { get; set; }
        public double DamageDealt = 0.0;

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
                foreach (var unit in Units)
                {
                    if (unit.SkipAttack) continue;
                    if (unit.HackResult == ElectronicWarfareResult.DealNoDamage) { }
                    else
                    {
                        if (unit.HackResult == ElectronicWarfareResult.None || unit.HackResult == ElectronicWarfareResult.TakeDamage)
                            attack += unit.AttackPower;
                        else if (unit.HackResult == ElectronicWarfareResult.DealHalfDamage)
                            attack += (unit.AttackPower / 2);

                        if (unit.IsCommandAndControl)
                            attack += 2;
                    }
                }
                return attack;
            }
        }

        public void RaiseHPAPQuantityChanged()
        {
            RaisePropertyChanged(nameof(TotalUnits));
            RaisePropertyChanged(nameof(TotalHealth));
            RaisePropertyChanged(nameof(TotalAttack));
        }
        #endregion

        public CombatForce()
        {
        }
        public CombatForce(CombatForce otherForce)
        {
            Round = otherForce.Round;
            Name = otherForce.Name;

            CrewScore = otherForce.CrewScore;
            AttemptElectronicWarfare = otherForce.AttemptElectronicWarfare;
            HasAdvancedScanners = otherForce.HasAdvancedScanners;

            IsInvulnerable = otherForce.IsInvulnerable;
            SkipAttack = otherForce.SkipAttack;

            foreach (var unit in otherForce.Units)
            {
                AddUnit(new Unit(unit));
            }
            foreach (var unit in otherForce.DestroyedUnits)
            {
                unit.CombatForce = this;
                DestroyedUnits.Add(unit);
            }

            RaiseHPAPQuantityChanged();
        }

        #region Add/Remove
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

        public void AddAttacking ()
        {
            if (UI_ATTACKING == null) return;
            if (UI_ATTACKING.Name == Name) return;

            foreach (var s in Attacking)
            {
                if (s == UI_ATTACKING)
                    return;
            }

            Attacking.Add(UI_ATTACKING);
        }
        public void RemoveAttacking()
        {
            if (UI_ATTACKING == null) return;

            Attacking.Remove(UI_ATTACKING);
        }
        #endregion

        public bool HasShip(string shipName)
        {
            foreach (var unit in Units)
            {
                if (unit.Name == shipName)
                    return true;
            }
            return false;
        }

        public List<Unit> GetUnits(string name)
        {
            List<Unit> units = new List<Unit>();
            foreach (var unit in Units)
            {
                if (unit.Name == name)
                {
                    units.Add(unit);
                }
            }
            return units;
        }

        public List<Unit> GetSquadrons()
        {
            List<Unit> units = new List<Unit>();
            foreach (var unit in Units)
            {
                if (unit.Name.Contains("Squadron"))
                {
                    units.Add(unit);
                }
            }
            return units;
        }

        public override string ToString()
        {
            return string.Format("{0}, Attacking: {2}, Number of Units: {1}, HP: {3}, AP: {4}", Name, Units.Count, Attacking, TotalHealth, TotalAttack);
        }
    }
}
