using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims_Dept
{
    public enum TypeOfClaim
    {
        Auto = 1,
        Home,
        Theft,
        Fire,
        Flooding
    }
    public class ClaimItems
    {
        public int ClaimId { get; set; }
        public TypeOfClaim ClaimType { get; set; } 
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; } 
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public ClaimItems()
        {

        }

        public ClaimItems(int claimId, TypeOfClaim claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }

}
