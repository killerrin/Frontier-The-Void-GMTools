using Frontier_The_Void_GMTools.Models;
using Frontier_The_Void_GMTools.Models.EnumTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier_The_Void_GMTools.Settings
{
    public class UnitSettings
    {
        public List<Unit> Units { get; set; }

        public UnitSettings()
        {
            Units = new List<Unit>();
        }

        public void SetToDefault()
        {
            Debug.WriteLine("Setting Default UnitSettings");
            Units = new List<Unit>();

            #region Space Units
            Units.Add(new Unit()); // Unique Ships
            Unit superCarrier           = new Unit(UnitType.Space, "Super-Carrier", 40.0, 40.0, 35, 5, 1); Units.Add(superCarrier);
            Unit battleCarrier          = new Unit(UnitType.Space, "Battle Carrier", 50.0, 50.0, 30, 5, 1); Units.Add(battleCarrier);
            Unit superDreadnought       = new Unit(UnitType.Space, "Super-Dreadnought", 55.0, 55.0, 35, 5, 1); Units.Add(superDreadnought);
            Unit uniqueShip             = new Unit(UnitType.Space, "Unique Ship", 0.0, 0.0, 0, 5, 1); Units.Add(uniqueShip);

            Units.Add(new Unit()); // First Rates
            Unit fleetCarrier           = new Unit(UnitType.Space, "Fleet Carrier", 19.5, 19.5, 20, 5, 1); Units.Add(fleetCarrier);
            Unit battleCruiser          = new Unit(UnitType.Space, "Battle Cruiser", 22.0, 22.0, 21, 5, 1); Units.Add(battleCruiser);
            Unit battleShip             = new Unit(UnitType.Space, "Battleship", 25.0, 25.0, 23, 5, 1); Units.Add(battleShip);
            Unit dreadnought            = new Unit(UnitType.Space, "Dreadnought", 32.0, 32.0, 25, 5, 1); Units.Add(dreadnought);

            Units.Add(new Unit()); // Second Rates
            Unit cruiser                = new Unit(UnitType.Space, "Cruiser", 7.0, 7.0, 15, 10, 1); Units.Add(cruiser);
            Unit heavyCruiser           = new Unit(UnitType.Space, "Heavy Cruiser", 10.0, 10.0, 16, 10, 1); Units.Add(heavyCruiser);
            Unit carrier                = new Unit(UnitType.Space, "Carrier", 10.0, 10.0, 17, 10, 1); Units.Add(carrier);

            Units.Add(new Unit()); // Third Rates
            Unit destroyer              = new Unit(UnitType.Space, "Destroyer", 5.0, 5.0, 10, 15, 3); Units.Add(destroyer);
            Unit areaDefenceDestroyer   = new Unit(UnitType.Space, "Area Defence Destroyer", 5.0, 0.0, 10, 15, 2); Units.Add(areaDefenceDestroyer);
            Unit lightCruiser           = new Unit(UnitType.Space, "Light Cruiser", 6.0, 6.0, 12, 15, 2); Units.Add(lightCruiser);
            Unit lightCarrier           = new Unit(UnitType.Space, "Light Carrier", 7.5, 7.5, 13, 15, 1); Units.Add(lightCarrier);

            Units.Add(new Unit()); // Fourth Rates
            Unit corvette               = new Unit(UnitType.Space, "Corvette", 1.0, 1.0, 5, 20, 10); Units.Add(corvette);
            Unit frigate                = new Unit(UnitType.Space, "Frigate", 2.0, 2.0, 7, 20, 5); Units.Add(frigate);
            Unit heavyFrigate           = new Unit(UnitType.Space, "Heavy Frigate", 3.0, 3.0, 8, 20, 5); Units.Add(heavyFrigate);

            Units.Add(new Unit()); // Fighters/Super-Light Weight Ships
            Unit fighter                = new Unit(UnitType.Space, "Fighter Squadron", 15.0, 0.0, 5, 50, 1); Units.Add(fighter);
            Unit strikeFighter          = new Unit(UnitType.Space, "Strike Fighter Squadron", 10.0, 10.0, 5, 50, 1); Units.Add(strikeFighter);
            Unit gunShip                = new Unit(UnitType.Ground, "Gun Ship Squadron", 15.0, 15.0, 5, 50, 1); Units.Add(gunShip);

            Units.Add(new Unit()); // Support Ships
            Unit supplyShip             = new Unit(UnitType.Space, "Supply Ship", 4.0, 0.0, 10, 20, 2); Units.Add(supplyShip);
            Unit assaultShip            = new Unit(UnitType.Space, "Assault Ship", 1.0, 1.0, 5, 20, 5); Units.Add(assaultShip);
            Unit commandoCarrier        = new Unit(UnitType.Space, "Commando Carrier", lightCarrier.Health, lightCarrier.AttackPower, lightCarrier.Cost, lightCarrier.BuildRate, lightCarrier.NumberBuildAtATime); Units.Add(commandoCarrier);
            Unit troopTransport         = new Unit(UnitType.Space, "Troop Transport", 4.0, 0.0, 2, 20, 10); Units.Add(troopTransport);
            #endregion

            #region Ground Units
            Units.Add(new Unit());
            Units.Add(new Unit());

            // Militia Battalions
            Unit militiaBattalionLight      = new Unit(UnitType.Ground, "Militia Battalion (Light)", 1.0, 1.0, 1, 45, 1); Units.Add(militiaBattalionLight);
            Unit militiaBattalionMechanized = new Unit(UnitType.Ground, "Militia Battalion (Mechanized)", 3.0, 3.0, 2, 45, 1); Units.Add(militiaBattalionMechanized);
            Unit militiaBattalionArmoured   = new Unit(UnitType.Ground, "Militia Battalion (Armoured)", 4.5, 5.0, 3, 45, 1); Units.Add(militiaBattalionArmoured);

            // Conscript Battalions
            Unit conscriptBattalionLight      = new Unit(UnitType.Ground, "Conscript Battalion (Light)", 2.0, 2.0, 2, 45, 1); Units.Add(conscriptBattalionLight);
            Unit conscriptBattalionMechanized = new Unit(UnitType.Ground, "Conscript Battalion (Mechanized)", 4.0, 4.0, 3, 45, 1); Units.Add(conscriptBattalionMechanized);
            Unit conscriptBattalionArmoured   = new Unit(UnitType.Ground, "Conscript Battalion (Armoured)", 5.5, 6, 4, 45, 1); Units.Add(conscriptBattalionArmoured);

            // Regular Battalions
            Unit regularBattalionLight      = new Unit(UnitType.Ground, "Regular Battalion (Light)", 4.0, 4.0, 3, 45, 1); Units.Add(regularBattalionLight);
            Unit regularBattalionMechanized = new Unit(UnitType.Ground, "Regular Battalion (Mechanized)", 6.0, 7.0, 4, 45, 1); Units.Add(regularBattalionMechanized);
            Unit regularBattalionArmoured   = new Unit(UnitType.Ground, "Regular Battalion (Armoured)", 7.5, 9.0, 5, 45, 1); Units.Add(regularBattalionArmoured);

            // Professional Battalions
            Unit professionalBattalionLight      = new Unit(UnitType.Ground, "Professional Battalion (Light)", 5.0, 5.0, 5, 45, 1); Units.Add(professionalBattalionLight);
            Unit professionalBattalionMechanized = new Unit(UnitType.Ground, "Professional Battalion (Mechanized)", 7.0, 9.0, 6, 45, 1); Units.Add(professionalBattalionMechanized);
            Unit professionalBattalionArmoured   = new Unit(UnitType.Ground, "Professional Battalion (Armoured)", 8.5, 11.0, 7, 45, 1); Units.Add(professionalBattalionArmoured);

            // Elite Battalions
            Unit eliteBattalionLight      = new Unit(UnitType.Ground, "Elite Battalion (Light)", 6.0, 7.0, 6, 45, 1); Units.Add(eliteBattalionLight);
            Unit eliteBattalionMechanized = new Unit(UnitType.Ground, "Elite Battalion (Mechanized)", 8.0, 10.0, 7, 45, 1); Units.Add(eliteBattalionMechanized);
            Unit eliteBattalionArmoured   = new Unit(UnitType.Ground, "Elite Battalion (Armoured)", 9.5, 11, 8, 45, 1); Units.Add(eliteBattalionArmoured);
            #endregion
        }

        public static UnitSettings Load()
        {
            Debug.WriteLine("Loading UnitSettings");
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(UnitSettings));
            
            try {
                StreamReader file = new StreamReader("UnitStatistics.xml");
                UnitSettings settings = (UnitSettings)reader.Deserialize(file);
                file.Close();

                Debug.WriteLine("UnitSettings Successfully Loaded");
                return settings;
            }
            catch(IOException) {

                // Recreate and Save the Default Settings
                UnitSettings settings = new UnitSettings();
                settings.SetToDefault();

                // Save the Default Settings
                Save(settings);

                return settings;
            }
        }

        public static bool Save(UnitSettings settings)
        {
            Debug.WriteLine("Saving UnitSettings");
            try
            {
                var writer = new System.Xml.Serialization.XmlSerializer(typeof(UnitSettings));
                var wfile = new StreamWriter("UnitStatistics.xml");
                writer.Serialize(wfile, settings);
                wfile.Close();
            }
            catch(Exception) { return false; }
            return true;
        }
    }
}
