using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Komodo_Outings
{
    public enum TypeOfEvent
    {
        Golf =1,
        Skating,
        Bowling,
        Concert

    }
    public class OutingEvents
    {
        public TypeOfEvent EventType { get; set; }
        public int GuestCount { get; set; }
        public DateTime EventDate { get; set; }
        public decimal PerPersonCost { get; set; }
        public decimal EventCost { get; set; }

        public OutingEvents()
        {

        }

        public OutingEvents(TypeOfEvent eventType, int guestCount, DateTime eventDate, decimal perPersonCost, decimal eventCost)
        {
            EventType = eventType;
            GuestCount = guestCount;
            EventDate = eventDate;
            PerPersonCost = perPersonCost;
            EventCost = eventCost;
        }
    }

   
}
