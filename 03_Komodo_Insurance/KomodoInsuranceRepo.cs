using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Insurance
{
   public class KomodoInsuranceRepo
    {
        private Dictionary<int, EmployeeBadges> _employeeBadges = new Dictionary<int, EmployeeBadges>();
        int Count;
        //Create
        public void AddABadge(EmployeeBadges empBadge) 
        {
            Count++;
            _employeeBadges.Add(empBadge.BadgeID, empBadge);
        }

        //Read
        public Dictionary<int,EmployeeBadges> ViewAllBadges()
        {
            return _employeeBadges;
        }

        //Update
        public bool UpdateExistingBadge(int badgeId, EmployeeBadges newAccess)
        {
            EmployeeBadges oldAccess = GetById(badgeId);
            if (oldAccess != null) 
            {
                oldAccess.DoorAccess = newAccess.DoorAccess;
              // oldAccess.DoorAccess.Add(newAccess.DoorAccess);
                    return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public EmployeeBadges GetById(int badgeId)
        {
            foreach (KeyValuePair<int, EmployeeBadges> entry in _employeeBadges)
            {
                if (entry.Key == badgeId)
                {
                    return entry.Value; 
                }
            }
            return null;
        }
    }
}
