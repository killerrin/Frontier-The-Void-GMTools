using Frontier_The_Void_GMTools.DnDTools;
using Frontier_The_Void_GMTools.Models;
using Frontier_The_Void_GMTools.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;
        public MainWindowViewModel ViewModel { get { return (MainWindowViewModel)DataContext; } }

        public MainWindow()
        {
            Instance = this;
            InitializeComponent();
        } 

        private void frame_Loaded(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }

        #region Numbers Only Events
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

        #region Unit Statistics
        private void UnitStatistics_Click(object sender, RoutedEventArgs e)
        {
            unitStatisticsChildWindow.Show();
        }

        private void unitStatisticsChildWindow_MakeDefault_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.MakeDefault();
        }

        private void unitStatisticsChildWindow_unitListbox_AddAbove_Click(object sender, RoutedEventArgs e)
        {
            Unit newUnit = new Unit();
            newUnit.Name = unitNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(unitHealthTextBox.Text))
                newUnit.Health = 0.0;
            else
                newUnit.Health = Convert.ToInt32(unitHealthTextBox.Text);

            if (string.IsNullOrWhiteSpace(unitHealthTextBox.Text))
                newUnit.AttackPower = 0.0;
            else
                newUnit.AttackPower = Convert.ToInt32(unitAttackTextBox.Text);

            Button originalSource = (Button)e.OriginalSource;
            ViewModel.AddAbove((Unit)originalSource.DataContext, newUnit);
        }

        private void unitStatisticsChildWindow_unitListbox_X_Click(object sender, RoutedEventArgs e)
        {
            Button originalSource = (Button)e.OriginalSource;
            ViewModel.RemoveUnit((Unit)originalSource.DataContext);
        }
        #endregion

        private void unitStatisticsChildWindow_Load_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Load();
        }

        private void unitStatisticsChildWindow_Save_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Save();
        }
    }
}
