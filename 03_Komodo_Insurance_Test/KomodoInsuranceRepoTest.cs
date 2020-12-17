using _03_Komodo_Insurance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_Komodo_Insurance_Test
{
    [TestClass]
    public class KomodoInsuranceRepoTest
    {
        [TestClass]
        public class KomodoInsuranceTest 
        {
            private KomodoInsuranceRepo _insuranceRepo;
            private EmployeeBadges _employeeBadge;
            List<string> doors;
           
            [TestInitialize]
            public void Arrange()
            {
                _insuranceRepo = new KomodoInsuranceRepo();
                doors = new List<string> { "A10", "B1" };
                _employeeBadge = new EmployeeBadges(15,doors);

                _insuranceRepo.AddABadge(_employeeBadge);
               //  dictStuff = _insuranceRepo.ViewAllBadges();
            }

            [TestMethod]
            public void AddABadge()
            {
               var doors2 = new List<string> { "A10", "B1" };
               var _employeeBadge2 = new EmployeeBadges(15, doors2);
                _insuranceRepo.AddABadge(_employeeBadge2);

                int expected = 2;
                Assert.AreEqual(expected, _insuranceRepo.ViewAllBadges().Count);
            }

            [TestMethod]
            public void RemoveDoorNah()
            {
                bool expected = true;
                bool isSuccessful = _insuranceRepo.RemoveDoor(1, "A10");
                Assert.AreEqual(expected, isSuccessful);

            }

            [TestMethod]
            public void AddDoor()
            {
                string ExpectedName = "zoom317";
                _insuranceRepo.AddDoor(1, "zoom317");
                var dictStuff = _insuranceRepo.GetByKey(1);

                Assert.IsTrue(dictStuff.DoorAccess.Contains(ExpectedName));
            }

            [TestMethod]
            public void GetByKey()
            {
                int expected = 15;
                EmployeeBadges employeeBadges = _insuranceRepo.GetByKey(1);
                Assert.AreEqual(expected, employeeBadges.BadgeID);

            }
        }
    }
}
