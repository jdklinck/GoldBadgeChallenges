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
            ViewAllBadges();
            Console.WriteLine("Enter the badge id to update.");

            int badgeToUpdate = int.Parse(Console.ReadLine());
            EmployeeBadges updateBadge = new EmployeeBadges();
            EmployeeBadges testing = _insuranceRepo.GetById(badgeToUpdate);
            Console.WriteLine("Do you want to add or remove a door access? a/r");
            string input = Console.ReadLine();
            if (input =="a" || input == "A") 
            {
                Console.WriteLine("What door do they need access to?");
                // updateBadge.DoorAccess.Add(Console.ReadLine());
                testing.DoorAccess.Add(Console.ReadLine());
                Console.WriteLine("Door access added.");
            }
           if (input == "r" || input =="R") 
            {
                Console.WriteLine("What door would you like to remove.");
                // updateBadge.DoorAccess.Remove(Console.ReadLine());
                testing.DoorAccess.Remove(Console.ReadLine());
                Console.WriteLine("Door access removed.");
            }
           
        }

        private void ViewAllBadges()
        {
            Console.Clear();
            Dictionary<int, EmployeeBadges> badges = _insuranceRepo.ViewAllBadges();

            Console.WriteLine("Badge Id\t Door Access\t");
            foreach (KeyValuePair<int, EmployeeBadges> badge in badges)
            {
                Console.Write($" {badge.Key,-17}");
                foreach (var item in badge.Value.DoorAccess)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }

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
