using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Insurance
{
    public class EmployeeBadges
    {
        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; } = new List<string>();
    public EmployeeBadges()
    {

    }
        public EmployeeBadges(int badgeId, List<string> doorAccess)
        {
            BadgeID = badgeId;
            DoorAccess = doorAccess;
        }

    }
}
