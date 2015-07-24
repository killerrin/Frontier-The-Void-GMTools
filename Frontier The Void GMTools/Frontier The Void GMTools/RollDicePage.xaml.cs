using Frontier_The_Void_GMTools.DnDTools;
using Frontier_The_Void_GMTools.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frontier_The_Void_GMTools
{
    /// <summary>
    /// Interaction logic for RollDicePage.xaml
    /// </summary>
    public partial class RollDicePage : Page
    {
        RollDiceViewModel ViewModel {  get { return (RollDiceViewModel)DataContext; } }

        public RollDicePage()
        {
            InitializeComponent();
        }

        private void rollDiceButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Roll Dice Button Clicked");

            if (string.IsNullOrWhiteSpace(numberOfDiceTextBox.Text) ||
                string.IsNullOrWhiteSpace(sidesOnDiceTextBox.Text))
                return;

            Debug.WriteLine("Rolling Dice: Boxes not Empty");

            int numberOfDice;
            if (!int.TryParse(numberOfDiceTextBox.Text, out numberOfDice))
                return;

            Debug.WriteLine("Rolling Dice: Number of Dice Parsed: {0}", numberOfDice);

            int sidesOnDice;
            if (!int.TryParse(sidesOnDiceTextBox.Text, out sidesOnDice))
                return;

            Debug.WriteLine("Rolling Dice: Sides On Dice Parsed: {0}", sidesOnDice);
            
            ViewModel.RollDice(numberOfDice, sidesOnDice);
        }

        private void CheckNumbersOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !StringHelpers.IsTextAllowed(e.Text);
        }

        private void TextBoxPaste_CheckNumbers(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!StringHelpers.IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
