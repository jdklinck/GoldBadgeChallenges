using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims_Dept
{
    public class KomodoClaimsRepo
    {
        private Queue<ClaimItems> _claimItems = new Queue<ClaimItems>();

        public void AddNewClaim(ClaimItems claims)
        {
            _claimItems.Enqueue(claims);
        }

        public Queue<ClaimItems> GetClaimItems()
        {
            return _claimItems;
        }

        public void NextInQueue()
        {
            _claimItems.Dequeue();
        }

        public ClaimItems NextClaim()
        {
            ClaimItems NextClaim = _claimItems.Peek();
            return NextClaim;
        }

        public bool ValidateClaim(DateTime dateOfClaim, DateTime dateOfIncident,int lengthOfValidClaim)
        {
            int ans = dateOfIncident.Day - dateOfClaim.Day ;
            if (ans < lengthOfValidClaim && ans >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

