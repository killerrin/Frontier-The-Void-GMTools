using Frontier_The_Void_GMTools.DnDTools;
using Frontier_The_Void_GMTools.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for FTLPlanetGenerationPage.xaml
    /// </summary>
    public partial class FTLPlanetGenerationPage : Page
    {
        FTLPlanetaryGenerationViewModel ViewModel { get { return (FTLPlanetaryGenerationViewModel)DataContext; } }

        public FTLPlanetGenerationPage()
        {
            InitializeComponent();
        }

        private void PlanetaryGenerationRoll(object sender, RoutedEventArgs e)
        {
            planetaryGenerationRoll1TextBox.Text = ""+ViewModel.Die.Roll(20);
            planetaryGenerationRoll2TextBox.Text = ""+ViewModel.Die.Roll(20);
        }

        private void FTLGenerationRoll(object sender, RoutedEventArgs e)
        {
            ftlRoll1TextBox.Text = "" + ViewModel.Die.Roll(100);

            if (ftlExplorerCheckbox.IsChecked.Value == true)
                ftlRoll2TextBox.Text = "" + ViewModel.Die.Roll(100);
            else
                ftlRoll2TextBox.Text = "";
        }

        private void GenerateButtonClicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Generate System Button Clicked");

            if (string.IsNullOrWhiteSpace(hexXCoordinateTextBox.Text) || string.IsNullOrWhiteSpace(hexYCoordinateTextBox.Text))
            { }
            if (string.IsNullOrWhiteSpace(planetaryGenerationRoll1TextBox.Text) || string.IsNullOrWhiteSpace(planetaryGenerationRoll2TextBox.Text))
                return;
            if (string.IsNullOrWhiteSpace(ftlRoll1TextBox.Text) && string.IsNullOrWhiteSpace(ftlRoll2TextBox.Text))
                return;

            Debug.WriteLine("All Fields Entered");

            HexCoordinate hexCoordinate = new HexCoordinate();
            if (!int.TryParse(hexXCoordinateTextBox.Text, out hexCoordinate.X))
                hexCoordinate.X = ViewModel.Die.Roll(100);
            if (!int.TryParse(hexYCoordinateTextBox.Text, out hexCoordinate.Y))
                hexCoordinate.Y = ViewModel.Die.Roll(100);

            Debug.WriteLine("Hex Coordinate Validated");

            int planetGenerationRoll1;
            int planetGenerationRoll2;
            if (!int.TryParse(planetaryGenerationRoll1TextBox.Text, out planetGenerationRoll1))
                return;
            if (!int.TryParse(planetaryGenerationRoll2TextBox.Text, out planetGenerationRoll2))
                return;

            Debug.WriteLine("Planetary Generation Rolls Validated");

            int ftlRoll1 = 0;
            int ftlRoll2 = 0;
            if (!int.TryParse(ftlRoll1TextBox.Text, out ftlRoll1)) { }
            if (!int.TryParse(ftlRoll2TextBox.Text, out ftlRoll2)) { }

            Debug.WriteLine("FTL Rolls Validated");

            try
            {
                ViewModel.GenerateSystem(hexCoordinate, planetGenerationRoll1, planetGenerationRoll2, ftlRoll1, ftlRoll2, ftlExplorerCheckbox.IsChecked.Value, seedHexCheckBox.IsChecked.Value, seedPlanetaryGenerationCheckBox.IsChecked.Value, seedFTLCheckBox.IsChecked.Value);
            }
            catch (Exception) { }
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
