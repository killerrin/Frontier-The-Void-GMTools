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
    public class RollDiceViewModel : ViewModelBase
    {
        Dice dice = new Dice();

        private ObservableCollection<string> m_diceRolls = new ObservableCollection<string>();
        public ObservableCollection<string> DiceRolls
        {
            get { return m_diceRolls; }
            set
            {
                if (m_diceRolls == value)
                    return;

                m_diceRolls = value;
                RaisePropertyChanged(nameof(DiceRolls));
            }
        }

        /// <summary>
        /// Initializes a new instance of the RollDiceViewModel class.
        /// </summary>
        /// 
        public RollDiceViewModel()
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
            ObservableCollection<string> temp = new ObservableCollection<string>();

            if (numberOfDice == 1)
            {
                temp.Add(string.Format("Rolled {0}d{1} : {2}, total {2}", numberOfDice, sidesOnDice, dice.Roll(numberOfDice, sidesOnDice)));
            }
            else
            {
                var rolls = dice.RollMultiple(numberOfDice, sidesOnDice);
                foreach (var roll in rolls)
                {
                    temp.Add(string.Format("Rolled {0}d{1} : {2}, total {2}", numberOfDice, sidesOnDice, roll));
                }
            }
            DiceRolls = temp;
        }
    }
}