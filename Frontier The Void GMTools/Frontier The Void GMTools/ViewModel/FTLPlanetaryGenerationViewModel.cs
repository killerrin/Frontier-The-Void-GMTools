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
                    seed = int.Parse(hexCoordinate.X + "" + hexCoordinate.Y);
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
                Debug.WriteLine("Seeded Dice");
            }
            else Die = new Dice();

            // Now that everything is setup, begin generating the system
            ObservableCollection<StarSystem> tempStarSystem = new ObservableCollection<StarSystem>();

            FTLTravelResult = FindFTLResult(isExplorer, ftlRoll1, ftlRoll2);
            int totalPlanetGeneration = planetaryGenerationRoll1 + planetaryGenerationRoll2;

            int starRoll = Die.Roll(100);
            int totalStars = 1;
            if (starRoll > 90)
                totalStars = Die.Roll(4);

            // Fill the system with random bodies
            Debug.WriteLine("Rolling Objects in System");
            for (int i = 0; i < totalStars; i++)
            {
                Debug.WriteLine("New Star");
                StarSystem star = new StarSystem();
                star.Radiation = ((RadiationLevel)Die.RollBetween(0, ((int)RadiationLevel.Extreme) + 1));
                star.Classification = ((StarClassification)Die.RollBetween(0, (int)StarClassification.Blackhole) + 1);
                star.Age = ((StarAge)Die.RollBetween(0, (int)StarAge.EndOfLife) + 1);

                int totalBodies = Die.Roll(6);
                for (int x = 0; x < totalBodies; x++)
                {
                    star.CelestialBodies.Add(GenerateCelestialBody(FTLTravel.NormalSystem));
                }

                tempStarSystem.Add(star);
            }

            // Roll the Main Generator
            Debug.WriteLine("Generating the Planet from Inputs");
            CelestialObject generatedPlanet = GenerateCelestialBody(FTLTravelResult);
            generatedPlanet.CelestialType = CelestialBodyType.TerrestrialPlanet;
            tempStarSystem[0].CelestialBodies.Add(generatedPlanet);

            // Finally, update the collection
            Debug.WriteLine("Finished Generating System");
            GeneratedSystem = tempStarSystem;
        }

        public CelestialObject GenerateCelestialBody(FTLTravel ftlTravel)
        {
            Debug.WriteLine("Generating Celestial Bodies: {0}", ftlTravel);

            CelestialObject celestialBody = new CelestialObject();
            celestialBody.CelestialType = CalculateCelestialType();
            celestialBody.TerraformingTier = CalculateTerraformingTier();
            celestialBody.StageOfLife = CalculateStageOfLife();
            celestialBody.ResourceValue = CalculateResourceValue(ftlTravel, celestialBody.TerraformingTier);

            if (celestialBody.CelestialType == CelestialBodyType.Wormhole ||
                celestialBody.CelestialType == CelestialBodyType.Blackhole)
            {
                celestialBody.StageOfLife = LifeStage.None;
            }

            if (celestialBody.StageOfLife == LifeStage.SentientLife) //|| ftlTravel == FTLTravel.AlreadyColonized)
            {
                int numSpeciesRoll = Die.Roll(20);
                int numSpecies = 1;
                if (numSpeciesRoll < 15) numSpeciesRoll = 1;
                else numSpeciesRoll = Die.Roll(5);

                for (int i = 0; i < numSpecies; i++)
                {
                    celestialBody.Sentients.Add(GenerateSentientSpecies());
                }
            }

            return celestialBody;
        }
        public SentientSpecies GenerateSentientSpecies()
        {
            Debug.WriteLine("Generating Sentient Species");
            SentientSpecies sentientSpecies = new SentientSpecies();

            // Calculate Tech Level
            int techLevelRoll = Die.Roll(2,20);
            if (techLevelRoll <= 6)         sentientSpecies.TechLevel = CivilizationTechLevel.Cavemen;
            else if (techLevelRoll <= 12)   sentientSpecies.TechLevel = CivilizationTechLevel.StoneAge;
            else if (techLevelRoll <= 16)   sentientSpecies.TechLevel = CivilizationTechLevel.BronzeAge;
            else if (techLevelRoll <= 20)   sentientSpecies.TechLevel = CivilizationTechLevel.IronAge;
            else if (techLevelRoll <= 24)   sentientSpecies.TechLevel = CivilizationTechLevel.IndustrialRevolution;
            else if (techLevelRoll <= 30)   sentientSpecies.TechLevel = CivilizationTechLevel.AtomicAge;
            else if (techLevelRoll <= 32)   sentientSpecies.TechLevel = CivilizationTechLevel.SpaceAge;
            else if (techLevelRoll <= 36)   sentientSpecies.TechLevel = CivilizationTechLevel.DigitalAge;
            else if (techLevelRoll <= 40)   sentientSpecies.TechLevel = CivilizationTechLevel.InterstellarAge;
            else sentientSpecies.TechLevel = CivilizationTechLevel.StoneAge;

            // Calculate Traits
            Debug.WriteLine("Calculating Species Civilization Traits");
            while (true)
            {
                int civTraitsRoll = Die.Roll(1, 100);
                CivilizationTraits trait;
                if (civTraitsRoll <= 10) { trait = CivilizationTraits.Capitalist; }
                else if (civTraitsRoll <= 20) { trait = CivilizationTraits.Communist; }
                else if (civTraitsRoll <= 30) { trait = CivilizationTraits.Corporate; }
                else if (civTraitsRoll <= 40) { trait = CivilizationTraits.Explorer; }
                else if (civTraitsRoll <= 50) { trait = CivilizationTraits.Imperialist; }
                else if (civTraitsRoll <= 60) { trait = CivilizationTraits.PeaceKeepers; }
                else if (civTraitsRoll <= 70) { trait = CivilizationTraits.Philosophical; }
                else if (civTraitsRoll <= 80) { trait = CivilizationTraits.Scientist; }
                else if (civTraitsRoll <= 90) { trait = CivilizationTraits.Theocratic; }
                else if (civTraitsRoll <= 100) { trait = CivilizationTraits.Warmonger; }
                else trait = CivilizationTraits.Imperialist;

                bool acceptableTrait = true;
                if (sentientSpecies.Traits.Count == 0) { }
                else
                {
                    foreach (var t in sentientSpecies.Traits)
                    {
                        if (trait == t) { acceptableTrait = false; break; }
                        else if ((trait == CivilizationTraits.Imperialist && t == CivilizationTraits.PeaceKeepers) ||
                                 (trait == CivilizationTraits.PeaceKeepers && t == CivilizationTraits.Imperialist)) { acceptableTrait = false; break; }

                        else if ((trait == CivilizationTraits.Communist && t == CivilizationTraits.Capitalist) ||
                                 (trait == CivilizationTraits.Capitalist && t == CivilizationTraits.Communist)) { acceptableTrait = false; break; }
                    }
                }

                if (acceptableTrait)
                    sentientSpecies.Traits.Add(trait);
                if (sentientSpecies.Traits.Count >= 3)
                    break;
            }

            // Calculate Physiology
            Debug.WriteLine("Calculating Species Physiology");
            while (true)
            {
                AnimalClassification classification;
                int speciesPhysiologyRoll = Die.Roll(1, 100);
                if (speciesPhysiologyRoll <= 10) classification = AnimalClassification.Amphibian;
                else if (speciesPhysiologyRoll <= 20) classification = AnimalClassification.Avian;
                else if (speciesPhysiologyRoll <= 30) classification = AnimalClassification.Aquatic;
                else if (speciesPhysiologyRoll <= 50) classification = AnimalClassification.Reptillian;
                else if (speciesPhysiologyRoll <= 75) classification = AnimalClassification.Mammal;
                else if (speciesPhysiologyRoll <= 85) classification = AnimalClassification.Rock;
                else if (speciesPhysiologyRoll <= 95) classification = AnimalClassification.Energy;
                else if (speciesPhysiologyRoll <= 98) classification = AnimalClassification.Exotic;
                else if (speciesPhysiologyRoll <= 100) classification = AnimalClassification.SpaceBased;
                else classification = AnimalClassification.Mammal;
                Debug.WriteLine("Rolling Species Physiology: {0}, {1}", speciesPhysiologyRoll, classification);

                bool acceptableClassification = true;
                foreach (var c in sentientSpecies.Classifications)
                {
                    if (classification == c) { acceptableClassification = false; break; }
                }

                if (acceptableClassification)
                {
                    Debug.Write(" | Classification Accepted");
                    sentientSpecies.Classifications.Add(classification);
                    if (Die.Roll(20) < 10)
                        break;
                }

                if (sentientSpecies.Classifications.Count >= 4) break;
            }

            return sentientSpecies;
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
            else if (roll <= 22)    return LifeStage.SimpleLife;
            else if (roll <= 37)    return LifeStage.ComplexLife;
            else if (roll <= 40)    return LifeStage.SentientLife;

            return LifeStage.None;
        }
        public int CalculateResourceValue(FTLTravel ftlTravelResult, TerraformationTier terraformationTier)
        {
            if (ftlTravelResult == FTLTravel.DeathWorld)                return Die.Roll(20);
            else if (ftlTravelResult == FTLTravel.GoodSystem)           return Die.RollBetween(4, 5 + 1);
            else if (ftlTravelResult == FTLTravel.BeyondComprehension)  return 5;
            else if (ftlTravelResult == FTLTravel.HyperResourceWorld)   return Die.RollBetween(6, 10 + 1);
            else if (terraformationTier == TerraformationTier.T5)       return Die.RollBetween(3, 5 + 1);
            return Die.Roll(4);
        }
    }
}