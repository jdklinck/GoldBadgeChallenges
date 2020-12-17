using _03_Komodo_Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Insurance_App
{
    class Program_UI
    {
        private readonly KomodoInsuranceRepo _insuranceRepo = new KomodoInsuranceRepo();

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
                Console.WriteLine("Please select a menu option:\n" +
                    "1. Add an employee badge\n" +
                    "2. Edit an employee badge\n" +
                    "3. List all employee badges\n" +
                    "4. Exit menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void AddBadge()
        {
            Console.Clear();
            bool hasAccess = false;
            EmployeeBadges badges = new EmployeeBadges();

            Console.WriteLine("Please enter the employee badge.");
            badges.BadgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the door needed for access.");
            badges.DoorAccess.Add(Console.ReadLine());

            while (hasAccess == false)
            {
                Console.WriteLine("Do you need access to any more doors? y/n");
                string inputNeeded = Console.ReadLine();

                if (inputNeeded == "y" || inputNeeded == "Y")
                {
                    Console.WriteLine("Enter the door needed for access");
                    badges.DoorAccess.Add(Console.ReadLine());
                }

                if (inputNeeded == "n" || inputNeeded == "N")
                {
                    hasAccess = true;
                }
            }
            _insuranceRepo.AddABadge(badges);
            Console.WriteLine("The new badge has been added.");
        }

        private void UpdateBadge()
        {
            Console.Clear();
            Console.WriteLine("Choose a menu option.\n" +
                              "1.Remove Door\n" +
                              "2.Add Door\n" +
                              "3.Main Menu");

            int userInput = int.Parse(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    RemoveDoor();
                    break;
                case 2:
                    AddDoor();
                    break;
                case 3:
                    BackToMainMenu();
                    break;
                default:
                    Console.WriteLine("Sorry wrong Selection.");
                    break;
            }

        }

        private void BackToMainMenu()
        {
            Menu();
        }

        private void AddDoor()
        {
            Console.Clear();
            ViewAllBadges();

            Console.WriteLine("Please enter a Dictionary Key.");
            int badgeByKey = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the door name to be added.");
            string doorName = Console.ReadLine();

          bool isSuccessful= _insuranceRepo.AddDoor(badgeByKey, doorName);
            if (isSuccessful)
            {
                Console.WriteLine($"Door Added: {doorName}");
            }
            else
            {
                Console.WriteLine($"{doorName} Failed to be added.");

            }

        }

        private void RemoveDoor()
        {
            Console.Clear();
            ViewAllBadges();

            Console.WriteLine("Please enter a Dictionary Key.");
            int userInput = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the door name to be removed.");
            string doorName = Console.ReadLine();

           bool isSuccessful= _insuranceRepo.RemoveDoor(userInput, doorName);
            if (isSuccessful)
            {
                Console.WriteLine($"Door Removed: {userInput}");
            }
            else
            {
                Console.WriteLine($"{userInput} Failed to be removed.");

            }
        }

        private void ViewAllBadges()
        {
            Console.Clear();
            Dictionary<int, EmployeeBadges> badges = _insuranceRepo.ViewAllBadges();

            //Console.WriteLine("Badge Id\t Door Access\t");
            foreach (var badge in badges)
            {
                //Console.Write($" {badge,-17}");
                Console.WriteLine($"DictKey: {badge.Key}");
                ViewBadgeInfo(badge.Value);
            }

        }


        private void ViewBadgeInfo(EmployeeBadges badge)
        {
            Console.WriteLine($"Badge Id: {badge.BadgeID}");
           
            foreach (var item in badge.DoorAccess)
            {
                Console.Write($"{item}\n");
               
            }
         
            Console.WriteLine("************************");
        }


        private void SeedList()
        {

            EmployeeBadges employeeBadges1 =
                new EmployeeBadges(10,
                new List<string> { "A2", "A7" });

            EmployeeBadges employeeBadges2 =
                new EmployeeBadges(11,
                new List<string> { "A5" });

            EmployeeBadges employeeBadges3 =
                new EmployeeBadges(12,
                new List<string> { "A3", "A6", "A9" });

            _insuranceRepo.AddABadge(employeeBadges1);
            _insuranceRepo.AddABadge(employeeBadges2);
            _insuranceRepo.AddABadge(employeeBadges3);



        }
    }
}
