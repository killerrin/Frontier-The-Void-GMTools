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
        public ObservableCollection<CelestialObject> OrbitingObjects = new ObservableCollection<CelestialObject>();
        public ObservableCollection<SentientSpecies> Sentients = new ObservableCollection<SentientSpecies>();

        public CelestialBodyType CelestialType;
        public TerraformationTier TerraformingTier;
        public LifeStage StageOfLife;
        public int ResourceValue;
     

        public CelestialObject()
        {

        }   
    }
}
