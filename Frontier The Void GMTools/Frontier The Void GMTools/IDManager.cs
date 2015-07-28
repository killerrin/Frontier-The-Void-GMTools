using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier_The_Void_GMTools
{
    public class IDManager
    {
        private object lockObject = new object();
        public uint CurrentID { get; set; }

        public IDManager()
        {
            CurrentID = 0;
        }

        public void Reset() { CurrentID = 0; }

        public uint GetNewID()
        {
            uint IDToUse;
            lock (lockObject)
            {
                IDToUse = CurrentID;
                IncrimentID();
            }

            return IDToUse;
        }

        private void IncrimentID()
        {
            if (CurrentID < uint.MaxValue)
                CurrentID++;
            else
                CurrentID = uint.MinValue;
        }
    }
}
