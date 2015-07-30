using Frontier_The_Void_GMTools.DnDTools;
using Frontier_The_Void_GMTools.Models;
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
    /// Interaction logic for CombatPage.xaml
    /// </summary>
    public partial class CombatPage : Page
    {
        CombatViewModel ViewModel { get { return (CombatViewModel)DataContext; } }

        public CombatPage()
        {
            InitializeComponent();
        }

        private void SimulateButton_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Simulate Combat Button Clicked");
            ViewModel.SimulateCombat();
        }

        #region Add/Remove Buttons
        private void AddCombatForceButton_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Add Combat Force Button Clicked");
            if (string.IsNullOrWhiteSpace(textBox_CombatGroupName.Text)) return;

            ViewModel.AddCombatForce(textBox_CombatGroupName.Text);
            textBox_CombatGroupName.Text = "";
        }

        private void RemoveCombatForceButton_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Remove Combat Force Button Clicked");

            Button originalSource = e.OriginalSource as Button;
            CombatForce combatForce = (CombatForce)originalSource.DataContext;
            ViewModel.RemoveCombatForce(combatForce);
        }

        private CombatForce addUnitCombatForce;
        private void AddUnitButton_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Add Unit Button Clicked");
            addUnitCombatForce = (CombatForce)((e.OriginalSource as Button)).DataContext;
            addUnitChildWindow.Show();
        }

        private void SubmitUnitButton_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Submit Unit Button Clicked");
            if (string.IsNullOrWhiteSpace(nameTextBox_childWindow.Text) ||
                string.IsNullOrWhiteSpace(healthTextBox_childWindow.Text) ||
                string.IsNullOrWhiteSpace(attackValueTextBox_childWindow.Text))
            {
                return;
            }

            // Parse the Data out of the UI Elements
            string name = nameTextBox_childWindow.Text;

            double health = 0.0;
            if (!double.TryParse(healthTextBox_childWindow.Text, out health))
                return;

            double attackPower = 0.0;
            if (!double.TryParse(attackValueTextBox_childWindow.Text, out attackPower))
                return;

            int quantityOfUnits = 1;
            if (!int.TryParse(quantityOfUnits_childWindow.Text, out quantityOfUnits))
                quantityOfUnits = 1;
            quantityOfUnits_childWindow.Text = "1";

            // Populate the CombatForce
            for (int i = 0; i < quantityOfUnits; i++)
            {
                Unit unit = new Unit();
                unit.Name = name;
                unit.Health = health;
                unit.AttackPower = attackPower;
                addUnitCombatForce.AddUnit(unit);
            }

            // Reset and Close
            presetComboBox_childWindow.SelectedIndex = 0;
            addUnitCombatForce = null;
            addUnitChildWindow.Close();
        }

        private void RemoveUnitButton_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Remove Unit Button Clicked");

            Button originalSource = e.OriginalSource as Button;
            Unit unit = (Unit)originalSource.DataContext;
            unit.CombatForce.RemoveUnit(unit);
        }

        private void RemoveAllUnitsButton_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Remove All Units Button Clicked");

            Button originalSource = e.OriginalSource as Button;
            CombatForce combatForce = (CombatForce)originalSource.DataContext;
            combatForce.RemoveAllUnits();
        }
        #endregion

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
