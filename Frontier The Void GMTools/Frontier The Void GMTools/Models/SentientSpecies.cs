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
        public ObservableCollection<AnimalClassification> Classifications { get; set; }
        public ObservableCollection<CivilizationTraits> Traits { get; set; }
        public CivilizationTechLevel TechLevel { get; set; }

        public SentientSpecies()
        {
            Classifications = new ObservableCollection<AnimalClassification>();
            Traits = new ObservableCollection<CivilizationTraits>();
        }
    }
}
