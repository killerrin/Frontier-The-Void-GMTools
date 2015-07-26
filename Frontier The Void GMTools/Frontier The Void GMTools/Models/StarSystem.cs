using Frontier_The_Void_GMTools.Models.EnumTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier_The_Void_GMTools.Models
{
    public class StarSystem
    {
        public ObservableCollection<CelestialObject> CelestialBodies { get; set; }
        public StarClassification Classification { get; set; }
        public RadiationLevel Radiation { get; set; }
        public StarAge Age { get; set; }

        public StarSystem()
        {
            CelestialBodies = new ObservableCollection<CelestialObject>();
        }
    }
}
