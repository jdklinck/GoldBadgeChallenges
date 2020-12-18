using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Komodo_Outings
{
    class KomodoOutingsRepo
    {
        private readonly List<OutingEvents> outingEvents = new List<OutingEvents>();

        public List<OutingEvents> ViewAllEvents()
        {
            return outingEvents;
        }

        public void AddOutingEvent(OutingEvents events)
        {
            outingEvents.Add(events);
        }
        
        //Nevermind... My brain is not willing to do calculations tonight :)
    }
}
