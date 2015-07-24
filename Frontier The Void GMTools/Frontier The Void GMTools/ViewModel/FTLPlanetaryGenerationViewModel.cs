using Frontier_The_Void_GMTools.DnDTools;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

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
    public class FTLPlanetaryGenerationViewModel : ViewModelBase
    {
        public const string GeneratedSystemPropertyName = "GeneratedSystem";
        public Dice Dice = new Dice();

        private ObservableCollection<object> m_generatedSystem = new ObservableCollection<object>();
        public ObservableCollection<object> GeneratedSystem
        {
            get { return m_generatedSystem; }
            set
            {
                if (m_generatedSystem == value)
                    return;

                m_generatedSystem = value;
                RaisePropertyChanged(GeneratedSystemPropertyName);
            }
        }

        /// <summary>
        /// Initializes a new instance of the RollDiceViewModel class.
        /// </summary>
        /// 
        public FTLPlanetaryGenerationViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}   
        }

        public void GenerateSystem(HexCoordinate hexCoordinate, int planetaryGenerationRoll1, int planetaryGenerationRoll2, int ftlRoll1, int ftlRoll2, bool isExplorer, bool seedHex, bool seedPlanetaryGeneration, bool seedFTL)
        {
            Debug.WriteLine("Generating System : Hex:{0}, PG1:{1}, PG2:{2}, FTL1:{3}, FTL2:{4}, IsExplorer:{5}, SeedHex:{6}, SeedPG:{7}, SeedFTL:{8}", hexCoordinate, planetaryGenerationRoll1, planetaryGenerationRoll2, ftlRoll1, ftlRoll2, isExplorer, seedHex, seedPlanetaryGeneration, seedFTL);

            // Spec allows Explorer to roll a 2d100 on FTL with their best roll being chosen as the active roll on the generation
            int activeFTLRoll;
            if (isExplorer)
            {
                if (ftlRoll1 >= ftlRoll2)
                    activeFTLRoll = ftlRoll1;
                else
                    activeFTLRoll = ftlRoll2;
            }
            else activeFTLRoll = ftlRoll1;

        }
    }
}