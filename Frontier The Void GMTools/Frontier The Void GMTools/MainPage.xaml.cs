﻿using System;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            Loaded += MainPage_Loaded;
            InitializeComponent();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.CurrentPage = PageName.MainPage;
        }

        private void RollDiceButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.CurrentPage = PageName.RollDice;
            MainWindow.Instance.frame.Navigate(new Uri("RollDicePage.xaml", UriKind.Relative));
        }

        private void FTLPlanetGenerationButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.CurrentPage = PageName.FTLPlanetaryGenerator;
            MainWindow.Instance.frame.Navigate(new Uri("FTLPlanetGenerationPage.xaml", UriKind.Relative));
        }

        private void CombatButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.CurrentPage = PageName.Combat;
            MainWindow.Instance.frame.Navigate(new Uri("CombatPage.xaml", UriKind.Relative));
        }
    }
}
