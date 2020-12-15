using _02_Komodo_Claims_Dept;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Komodo_Claims_Test
{
    [TestClass]
    public class KomodoClaimsRepoTest
    {
        [TestClass]
        public class KomodoClaimsTest
        {
            private KomodoClaimsRepo _claimsRepo;
            private ClaimItems _claimsItem;

            [TestInitialize]
            public void Arrange()
            {
                _claimsRepo = new KomodoClaimsRepo();
                _claimsItem = new ClaimItems(18, TypeOfClaim.Fire, "Sheshed caught fire", 2500.00m, new DateTime(2020, 12, 10), new DateTime(2020, 12, 11), true);

                _claimsRepo.AddNewClaim(_claimsItem);
            }

            [TestMethod]
            public void AddNewClaim()
            {
                int expected = 2;

                ClaimItems _claimsItem1 = new ClaimItems(18, TypeOfClaim.Auto, "Sheshed caught fire", 500.00m, new DateTime(2020, 12, 10), new DateTime(2020, 12, 11), true);
                _claimsRepo.AddNewClaim(_claimsItem1);
                List<ClaimItems> claims = _claimsRepo.GetClaimItems().ToList();

                Console.WriteLine($"Claims Amt: {claims.Count}");

                int actual = claims.Count;

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void GetClaimItems()
            {
                int expected = 1;
                List<ClaimItems> claims = _claimsRepo.GetClaimItems().ToList();

                Console.WriteLine($"Claims Total: {claims.Count}");

                int actual = claims.Count;

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void NextInQueue()
            {
                TypeOfClaim expected = TypeOfClaim.Fire;

                ClaimItems claim = _claimsRepo.NextClaim();

                Assert.AreEqual(expected, claim.ClaimType);
                
            }
        }
    }
}

