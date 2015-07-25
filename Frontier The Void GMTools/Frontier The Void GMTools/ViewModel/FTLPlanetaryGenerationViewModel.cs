using Frontier_The_Void_GMTools.DnDTools;
using Frontier_The_Void_GMTools.Models;
using Frontier_The_Void_GMTools.Models.EnumTypes;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System;

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
        public const string FTLTravelResultPropertyName = "FTLTravelResult";

        public Dice Die = new Dice();

        private ObservableCollection<StarSystem> m_generatedSystem = new ObservableCollection<StarSystem>();
        public ObservableCollection<StarSystem> GeneratedSystem
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

        private FTLTravel m_FTLTravelResult = FTLTravel.None;
        public FTLTravel FTLTravelResult
        {
            get { return m_FTLTravelResult; }
            set
            {
                if (m_FTLTravelResult == value)
                    return;

                m_FTLTravelResult = value;
                RaisePropertyChanged(FTLTravelResultPropertyName);
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

            // First we will seed the dice so that the GM can pull up the system coordinates again with the same input values
            if (seedHex || seedPlanetaryGeneration || seedFTL)
            {
                int seed = 1;
                if (seedHex)
                {
                    seed *= hexCoordinate.X;
                    seed *= hexCoordinate.Y;
                }
                if (seedPlanetaryGeneration)
                {
                    seed += planetaryGenerationRoll1;
                    seed += planetaryGenerationRoll2;
                } 
                if (seedFTL)
                {
                    seed += ftlRoll1;
                    seed += ftlRoll2;
                }

                Die.ChangeSeed(seed);
            }

            // Now that everything is setup, begin generating the system
            ObservableCollection<StarSystem> tempStarSystem = new ObservableCollection<StarSystem>();

            FTLTravelResult = FindFTLResult(isExplorer, ftlRoll1, ftlRoll2);
            int totalPlanetGeneration = planetaryGenerationRoll1 + planetaryGenerationRoll2;

            int starRoll = Die.Roll(100);
            int totalStars = 1;
            if (starRoll > 90)
                totalStars = Die.Roll(4);

            // Fill the system with random bodies
            for (int i = 0; i < totalStars; i++)
            {
                StarSystem star = new StarSystem();

                int totalBodies = Die.Roll(10);
                for (int x = 0; x < totalBodies; x++)
                {
                    star.CelestialBodies.Add(GenerateCelestialBody(FTLTravel.NormalSystem));
                }

                tempStarSystem.Add(star);
            }

            // Roll the Main Generator
            CelestialObject generatedPlanet = GenerateCelestialBody(FTLTravelResult);
            generatedPlanet.CelestialType = CelestialBodyType.TerrestrialPlanet;
            tempStarSystem[0].CelestialBodies.Add(generatedPlanet);

            // Finally, update the collection
            GeneratedSystem = tempStarSystem;
        }

        public CelestialObject GenerateCelestialBody(FTLTravel ftlTravel)
        {
            CelestialObject celestialBody = new CelestialObject();
            celestialBody.CelestialType = CalculateCelestialType();
            celestialBody.TerraformingTier = CalculateTerraformingTier();
            celestialBody.StageOfLife = CalculateStageOfLife();
            celestialBody.ResourceValue = CalculateResourceValue(ftlTravel);

            if (celestialBody.CelestialType == CelestialBodyType.Wormhole ||
                celestialBody.CelestialType == CelestialBodyType.Blackhole)
            {
                celestialBody.StageOfLife = LifeStage.None;
            }

            if (celestialBody.StageOfLife == LifeStage.SentientLife)
            {

            }

            return celestialBody;
        }

        public FTLTravel FindFTLResult(bool isExplorer, int ftlRoll1, int ftlRoll2)
        {
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

            if (activeFTLRoll <= 1)                                 return FTLTravel.DeathEvent;
            else if (activeFTLRoll >= 2 && activeFTLRoll <= 5)      return FTLTravel.HazardousEvent;
            else if (activeFTLRoll >= 7 && activeFTLRoll <= 15)     return FTLTravel.AlreadyColonized;
            else if ((activeFTLRoll >= 16 && activeFTLRoll <= 48) || (activeFTLRoll >= 52 && activeFTLRoll <= 85))
                                                                    return FTLTravel.NormalSystem;
            else if (activeFTLRoll >= 49 && activeFTLRoll <= 51)    return FTLTravel.DeathWorld;
            else if (activeFTLRoll >= 86 && activeFTLRoll <= 95)    return FTLTravel.GoodSystem;
            else if (activeFTLRoll == 96)                           return FTLTravel.BeyondComprehension;
            else if (activeFTLRoll >= 97 && activeFTLRoll <= 99)    return FTLTravel.HyperResourceWorld;
            else if (activeFTLRoll == 100)                          return FTLTravel.LostTechnology;

            return FTLTravel.NormalSystem;
        }
        public CelestialBodyType CalculateCelestialType()
        {
            int roll1 = Die.Roll(2, 100);
            if (roll1 <= 150)
            {
                int roll2 = Die.Roll(20);
                if (roll2 <= 4)
                    return CelestialBodyType.AsteroidBelt;
                else if (roll2 <= 9)
                    return CelestialBodyType.GasPlanet;
                return CelestialBodyType.TerrestrialPlanet;
            }
            else if (roll1 >= 180)
                return CelestialBodyType.Wormhole;
            return CelestialBodyType.Comet;
        }
        public TerraformationTier CalculateTerraformingTier()
        {
            int roll = Die.Roll(2,20);
            if (roll <= 2)       return TerraformationTier.Uninhabitable;
            else if (roll <= 8)  return TerraformationTier.T1;
            else if (roll <= 16) return TerraformationTier.T2;
            else if (roll <= 24) return TerraformationTier.T3;
            else if (roll <= 32) return TerraformationTier.T4;
            else if (roll <= 40) return TerraformationTier.T5;
            return TerraformationTier.T3;
        }
        public LifeStage CalculateStageOfLife()
        {
            int roll = Die.Roll(2, 20);
            if (roll <= 3)          return LifeStage.None;
            else if (roll <= 6)     return LifeStage.OrganicCompounds;
            else if (roll <= 10)    return LifeStage.SingleCellular;
            else if (roll <= 15)    return LifeStage.MultiCellular;
            else if (roll <= 20)    return LifeStage.SimpleLife;
            else if (roll <= 32)    return LifeStage.ComplexLife;
            else if (roll <= 40)    return LifeStage.SentientLife;

            return LifeStage.None;
        }
        public int CalculateResourceValue(FTLTravel ftlTravelResult)
        {
            if (ftlTravelResult == FTLTravel.DeathWorld)                return Die.Roll(20);
            else if (ftlTravelResult == FTLTravel.GoodSystem)           return Die.RollBetween(4, 5 + 1);
            else if (ftlTravelResult == FTLTravel.BeyondComprehension)  return 5;
            else if (ftlTravelResult == FTLTravel.HyperResourceWorld)   return Die.RollBetween(6, 10 + 1);
            return Die.Roll(4);
        }
    }
}