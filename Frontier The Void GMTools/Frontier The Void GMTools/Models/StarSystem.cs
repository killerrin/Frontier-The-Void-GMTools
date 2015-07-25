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
        public ObservableCollection<CelestialObject> CelestialBodies = new ObservableCollection<CelestialObject>();

        public StarSystem()
        {

        }
    }
}
