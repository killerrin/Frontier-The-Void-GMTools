/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Frontier_The_Void_GMTools"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Frontier_The_Void_GMTools.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<RollDiceViewModel>();
            SimpleIoc.Default.Register<FTLPlanetaryGenerationViewModel>();
            SimpleIoc.Default.Register<CombatViewModel>();
        }

        public MainViewModel vm_MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public RollDiceViewModel vm_RollDiceViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RollDiceViewModel>();
            }
        }

        public FTLPlanetaryGenerationViewModel vm_FTLPlanetGenerationViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FTLPlanetaryGenerationViewModel>();
            }
        }

        public CombatViewModel vm_CombatViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CombatViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}