using _02_Komodo_Claims_Dept;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims_App
{
    class Program_UI
    {
        private readonly KomodoClaimsRepo _claimsRepo = new KomodoClaimsRepo();

        public void Run()
        {
            SeedList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please choose a menu option:\n" +
                    "1. View all claims\n" +
                    "2. Take care of newxt claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ViewAllClaims()
        {
            Console.Clear();
            Queue<ClaimItems> claimItems = _claimsRepo.GetClaimItems();

            foreach (ClaimItems claim in claimItems)
            {
                ViewClaimsData(claim);
            }
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            ClaimItems claimItems = _claimsRepo.NextClaim();
            ViewClaimsData(claimItems);
            AskAQuestion("Do you want to deal with this claim now?(y/n)");
            string inputAnswer = Console.ReadLine();
            if (inputAnswer =="y")
            {
                _claimsRepo.NextInQueue(claimItems);
                Console.WriteLine("Claim removed.");
            }
            if (inputAnswer=="n")
            {
                Menu();
            }
        }
       
        private void ViewClaimsData(ClaimItems claim)
        {
            Console.WriteLine($"Claim ID: {claim.ClaimId}\n" +
                     $"Claim Type: {claim.ClaimType}\n" +
                     $"Description: {claim.Description}\n" +
                     $"Claim Amount: {claim.ClaimAmount}\n" +
                     $"Date of Incident: {claim.DateOfIncident}\n" +
                     $"Date of Claim:{claim.DateOfClaim}\n" +
                     $"Is Valid: {claim.IsValid}\n");
        }
        private void EnterNewClaim()
        {
            Console.Clear();
            ClaimItems newClaim = new ClaimItems();

            int lengthOfValidClaim = 30;

            Console.WriteLine("Enter the claim id.");
            newClaim.ClaimId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the claim type.\n" +
                "1. Auto \n" +
                "2. Home \n" +
                "3. Theft \n" +
                "4. Fire \n" +
                "5. Flooding");
            int claimTypes = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Enter a description for the claim.");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the amount of the claim.");
            decimal claimAmount = decimal.Parse(Console.ReadLine());
            newClaim.ClaimAmount = claimAmount;
           
            Console.WriteLine("Enter the date of the incident.");
            DateTime incidentDate = GiveMeADate("**Incident Date**");
            newClaim.DateOfIncident = incidentDate;

            Console.WriteLine("Enter the date of the claim.");
            DateTime claimDate = GiveMeADate("**Claim Date**");
            newClaim.DateOfClaim = claimDate;

            newClaim.IsValid = _claimsRepo.ValidateClaim(claimDate, incidentDate, lengthOfValidClaim);
            if (newClaim.IsValid)
            {
                Console.WriteLine("Claim is valid");
            }
            else
            {
                Console.WriteLine("Claim is not valid");
            }
            _claimsRepo.AddNewClaim(newClaim);

        }

        DateTime GiveMeADate(string messageTitle)
        {
            Console.WriteLine(messageTitle);
            AskAQuestion("Please input int value for the year.");
            int inputYear = int.Parse(Console.ReadLine());

            AskAQuestion("Please input int value for the Month.");
            int inputMonth = int.Parse(Console.ReadLine());

            AskAQuestion("Please input int value for the Day.");
            int inputDay = int.Parse(Console.ReadLine());

            DateTime dateTime = new DateTime(inputYear, inputMonth, inputDay);
            return dateTime;
        }

        void AskAQuestion(string message)
        {
            Console.WriteLine(message);
        }

        private void SeedList()
        {
            ClaimItems claimItems1 = new ClaimItems(10, TypeOfClaim.Auto, "Accident in CVS parking lot.", 1500.00m, new DateTime(2020, 11, 06), new DateTime(2020, 11, 08), true);
            ClaimItems claimItems2 = new ClaimItems(11, TypeOfClaim.Home, "Tree fell on roof.", 7500.00m, new DateTime(2020, 11, 08), new DateTime(2020, 11, 09), true);
            ClaimItems claimItems3 = new ClaimItems(12, TypeOfClaim.Theft, "Stolen iPhone.", 1200.00m, new DateTime(2020, 11, 10), new DateTime(2020, 12, 11), false);
            ClaimItems claimItems4 = new ClaimItems(13, TypeOfClaim.Fire, "Stove caught fire.", 5000.00m, new DateTime(2020, 11, 12), new DateTime(2020, 11, 13), true);
            ClaimItems claimItems5 = new ClaimItems(14, TypeOfClaim.Flooding, "Basement flooded", 8100.00m, new DateTime(2020, 11, 06), new DateTime(2020, 12, 08), false);

            _claimsRepo.AddNewClaim(claimItems1);
            _claimsRepo.AddNewClaim(claimItems2);
            _claimsRepo.AddNewClaim(claimItems3);
            _claimsRepo.AddNewClaim(claimItems4);
            _claimsRepo.AddNewClaim(claimItems5);
        }
    }
}
