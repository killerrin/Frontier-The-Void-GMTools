using Frontier_The_Void_GMTools.DnDTools;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows;

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
    public class GroundCombatViewModel : ViewModelBase
    {
        public const string DiceRollsPropertyName = "DiceRolls";

        Dice dice = new Dice();

        private ObservableCollection<int> m_diceRolls = new ObservableCollection<int>();
        public ObservableCollection<int> DiceRolls
        {
            get { return m_diceRolls; }
            set
            {
                if (m_diceRolls == value)
                    return;

                m_diceRolls = value;
                RaisePropertyChanged(DiceRollsPropertyName);
            }
        }

        /// <summary>
        /// Initializes a new instance of the RollDiceViewModel class.
        /// </summary>
        /// 
        public GroundCombatViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}   
        }
        
        public void RollDice(int numberOfDice, int sidesOnDice)
        {
            ObservableCollection<int> temp = new ObservableCollection<int>();
            var rolls = dice.RollMultiple(numberOfDice, sidesOnDice);
            foreach (var roll in rolls)
            {
                temp.Add(roll);
            }

            DiceRolls = temp;
        }
    }
}