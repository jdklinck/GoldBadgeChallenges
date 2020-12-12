using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims_Dept
{
    public class KomodoClaimsRepo
    {
        private readonly List<ClaimItems> claimItems = new List<ClaimItems>();

        //Create
        public void AddNewClaim(ClaimItems items)
        {
            claimItems.Add(items);
        }

        //Read
        public List<ClaimItems> ViewAllClaims()
        {
            return claimItems;
        }

        //Update
        //Next Claim ???

        //Delete

    }
}
