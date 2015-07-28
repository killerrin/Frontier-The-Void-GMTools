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

        private void AddUnitButton_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Add Unit Button Clicked");
            CombatForce combatForce = (CombatForce)((e.OriginalSource as Button)).DataContext;
        }

        private void RemoveUnitButton_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Remove Unit Button Clicked");

            Button originalSource = e.OriginalSource as Button;
            Unit unit = (Unit)originalSource.DataContext;
            unit.Owner.RemoveUnit(unit);
        }

        private void AttackingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("Combat Force Changed Attacking Target");
            CombatForce force = ((CombatForce)((ComboBox)e.OriginalSource).DataContext);
            Debug.WriteLine(force.Attacking);
        }
    }
}
