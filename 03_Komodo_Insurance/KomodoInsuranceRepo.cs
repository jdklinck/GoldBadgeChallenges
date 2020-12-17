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
            _employeeBadges.Add(Count, empBadge);
        }

        //Read
        public Dictionary<int, EmployeeBadges> ViewAllBadges()
        {
            return _employeeBadges;
        }

        //Update
        //public bool UpdateExistingBadge(int dictKey, EmployeeBadges newAccess)
        //{
        //    EmployeeBadges oldAccess = GetByKey(dictKey);
        //    if (oldAccess != null)
        //    {
        //        oldAccess.DoorAccess = newAccess.DoorAccess;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //Helper
        public EmployeeBadges GetByKey(int dictKey)
        {
            foreach (KeyValuePair<int, EmployeeBadges> entry in _employeeBadges)
            {
                if (entry.Key == dictKey)
                {
                    return entry.Value;
                }
            }
            return null;
        }


        public bool RemoveDoor(int dictKey, string doorName)
        {
            EmployeeBadges badges = GetByKey(dictKey);
            if (badges!= null)
            {
                foreach (var door in badges.DoorAccess)
                {
                    if (door == doorName)
                    {
                        badges.DoorAccess.Remove(door);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool AddDoor(int dictKey, string doorName)
        {
            EmployeeBadges badges = GetByKey(dictKey);
            if (badges == null)
            {
                return false;
            }
            else
            {
                badges.DoorAccess.Add(doorName);
                return true;
            }

        }
    }
}
