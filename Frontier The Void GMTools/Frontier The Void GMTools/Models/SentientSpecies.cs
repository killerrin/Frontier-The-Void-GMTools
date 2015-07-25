using Frontier_The_Void_GMTools.Models.EnumTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier_The_Void_GMTools.Models
{
    public class SentientSpecies
    {
        public ObservableCollection<AnimalClassification> Classifications = new ObservableCollection<AnimalClassification>();
        public ObservableCollection<CivTraits> Traits = new ObservableCollection<CivTraits>();
        public CivilizationTechLevel TechLevel;

        public SentientSpecies()
        {

        }
    }
}
