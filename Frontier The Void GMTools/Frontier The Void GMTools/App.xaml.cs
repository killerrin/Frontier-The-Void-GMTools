using Frontier_The_Void_GMTools.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Frontier_The_Void_GMTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static UnitSettings UnitStatisticsSettings;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            UnitStatisticsSettings = UnitSettings.Load();
        }
    }
}
