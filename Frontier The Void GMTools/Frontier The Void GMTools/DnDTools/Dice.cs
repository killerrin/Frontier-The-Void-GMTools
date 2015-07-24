using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier_The_Void_GMTools.DnDTools
{
    public class Dice
    {
        Random m_random;

        public Dice()
        {
            m_random = new Random();
        }

        public Dice(int seed)
        {
            m_random = new Random(seed);
        }

        public void ChangeSeed(int seed)
        {
            m_random = new Random(seed);
        }

        public int Roll(int sidesOnDice)
        {
            return m_random.Next(1, sidesOnDice + 1);
        }

        public List<int> RollMultiple(int numberOfDice, int sidesOnDice)
        {
            List<int> rolls = new List<int>();

            for (int i = 0; i < numberOfDice; i++)
            {
                rolls.Add(Roll(sidesOnDice));
            }

            return rolls;
        }
    }
}
