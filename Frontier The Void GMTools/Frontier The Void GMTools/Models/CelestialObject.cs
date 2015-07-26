using Frontier_The_Void_GMTools.Models.EnumTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier_The_Void_GMTools.Models
{
    public class CelestialObject
    {
        public ObservableCollection<CelestialObject> OrbitingObjects { get; set; }
        public ObservableCollection<SentientSpecies> Sentients { get; set; }

        public CelestialBodyType CelestialType { get; set; }
        public TerraformationTier TerraformingTier { get; set; }
        public LifeStage StageOfLife { get; set; }
        public int ResourceValue { get; set; }
     

        public CelestialObject()
        {
            OrbitingObjects = new ObservableCollection<CelestialObject>();
            Sentients = new ObservableCollection<SentientSpecies>();
        }   
    }
}
