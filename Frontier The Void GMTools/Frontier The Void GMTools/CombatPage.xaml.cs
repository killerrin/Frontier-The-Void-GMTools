using Frontier_The_Void_GMTools.DnDTools;
using Frontier_The_Void_GMTools.Models;
using Frontier_The_Void_GMTools.Models.EnumTypes;
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
            ViewModel.SimulateCombat((SimulatedCombatMode)simulatedCombatModeComboBox.SelectedIndex);
        }

        #region Add/Remove Buttons
        #region Rounds
        private void RemoveRoundButton_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Remove Round Button Clicked");
            Button button = (Button)e.OriginalSource;
            CombatRound round = (CombatRound)button.DataContext;
            ViewModel.RemoveRound(round);
        }

        private void clearSimulation_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Clear Simulation Button Clicked");
            ViewModel.ClearSimulation();
        }
        #endregion

        #region Combat Force
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
        #endregion

        #region Units
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
            if (string.IsNullOrWhiteSpace(nameTextBox_addUnit_childWindow.Text) ||
                string.IsNullOrWhiteSpace(healthTextBox_addUnit_childWindow.Text) ||
                string.IsNullOrWhiteSpace(attackValueTextBox_addUnit_childWindow.Text))
            {
                return;
            }

            // Parse the Data out of the UI Elements
            string name = nameTextBox_addUnit_childWindow.Text;

            double health = 0.0;
            if (!double.TryParse(healthTextBox_addUnit_childWindow.Text, out health))
                return;

            double attackPower = 0.0;
            if (!double.TryParse(attackValueTextBox_addUnit_childWindow.Text, out attackPower))
                return;

            int quantityOfUnits = 1;
            if (!int.TryParse(quantityOfUnits_addUnit_childWindow.Text, out quantityOfUnits))
                quantityOfUnits = 1;
            quantityOfUnits_addUnit_childWindow.Text = "1";

            // Populate the CombatForce
            Unit comboBoxSelectedUnit = presetComboBox_addUnit_childWindow.SelectedItem as Unit;
            for (int i = 0; i < quantityOfUnits; i++)
            {
                Unit unit = new Unit();
                unit.Name = name;
                unit.Health = health;
                unit.AttackPower = attackPower;

                if (commandAndControlCheckBox_addUnit_childWindow.IsChecked.HasValue)
                    unit.IsCommandAndControl = commandAndControlCheckBox_addUnit_childWindow.IsChecked.Value;
                else unit.IsCommandAndControl = false;

                try
                {
                    if (typeOfUnitComboBox_addUnit_childWindow.SelectedIndex < 0 ||
                        typeOfUnitComboBox_addUnit_childWindow.SelectedIndex > 2)
                        unit.TypeOfUnit = UnitType.Both;
                    else
                        unit.TypeOfUnit = (UnitType)typeOfUnitComboBox_addUnit_childWindow.SelectedIndex;
                }
                catch (Exception) { unit.TypeOfUnit = UnitType.Both; }

                addUnitCombatForce.AddUnit(unit);
            }

            // Reset and Close
            presetComboBox_addUnit_childWindow.SelectedIndex = 0;
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
        #endregion

        #region Input Restriction Events
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
        #endregion
    }
}
