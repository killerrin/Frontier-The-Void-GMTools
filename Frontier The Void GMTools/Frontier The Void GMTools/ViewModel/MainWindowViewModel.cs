using Frontier_The_Void_GMTools.Models;
using Frontier_The_Void_GMTools.Settings;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

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
    public class MainWindowViewModel : ViewModelBase
    {
        UnitSettings m_unitSettings = new UnitSettings();
        public UnitSettings UnitStatistics
        {
            get { return m_unitSettings; }
            set
            {
                if (m_unitSettings == value) return;
                m_unitSettings = value;
                RaisePropertyChanged(nameof(UnitStatistics));
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainWindowViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
                UnitStatistics = new UnitSettings();
                UnitStatistics.SetToDefault();
            }
            else
            {
                // Code runs "for real"
                UnitStatistics = App.UnitStatisticsSettings;
            }
            
        }

        public void MakeDefault()
        {
            UnitStatistics = new UnitSettings();
            UnitStatistics.SetToDefault();

            Save();
        }

        public void AddAbove(Unit unit, Unit unitToAdd)
        {
            int index = UnitStatistics.Units.IndexOf(unit);
            UnitStatistics.Units.Insert(index, unitToAdd);
        }
        public void RemoveUnit(Unit unit)
        {
            UnitStatistics.Units.Remove(unit);
        }

        public void Save()
        {
            App.UnitStatisticsSettings = UnitStatistics;
            UnitSettings.Save(UnitStatistics);
        }
        public void Load()
        {
            UnitStatistics = UnitSettings.Load();
            App.UnitStatisticsSettings = UnitStatistics;
        }


    }
}