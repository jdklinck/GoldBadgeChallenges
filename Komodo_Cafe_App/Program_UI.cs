using _01_Gold_Badge_Challenges_Komodo_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_App
{
    public class Program_UI
    {
        private readonly KomodoMenuRepo _MenuRepo = new KomodoMenuRepo();
        public void Run()
        {
            Seed();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Cafe\n" +
                   "Please select a menu option.\n" +
                   "1. View all menu items\n" +
                   "2. View meal item by number\n" +
                   "3. Create menu item\n" +
                   "4. Remove menu item\n" +
                   "5. Exit Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllMenuItems();
                        break;
                    case "2":
                        ViewMealItemByNumber();
                        break;
                    case "3":
                        AddItemToMenu();
                        break;
                    case "4":
                        RemoveItemFromMenu();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }


        private void ViewAllMenuItems()
        {
            Console.Clear();

            List<MenuItem> listOfItems = _MenuRepo.ViewMenuItem();

            foreach (var item in listOfItems)
            {
                DisplayItem(item);
                Console.WriteLine("*******************************************************");
            }
        }

        private void ViewMealItemByNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of the item you would like to view.");
            int userInput = int.Parse(Console.ReadLine());

            MenuItem item = _MenuRepo.GetMenuItemByNumber(userInput);
            DisplayItem(item);

        }

        private void AddItemToMenu()
        {
            Console.Clear();
            bool hasAllIngredients = false;
            MenuItem menuItem = new MenuItem();

            Console.WriteLine("Enter the number id for the item.");
            menuItem.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the name of the item.");
            menuItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter a description for the item.");
            menuItem.MealDescription = Console.ReadLine();

            while (hasAllIngredients == false)
            {
                Console.WriteLine("Do you want to add an ingredient? y/n ");
                string inputNeedIng = Console.ReadLine();
                Console.Clear();

                if (inputNeedIng == "y" || inputNeedIng =="Y")
                {
                    Console.WriteLine("Enter the ingredient you want to add.\n" +
                            "1. Lettuce\n" +
                            "2. Tomato\n" +
                            "3. Onion\n" +
                            "4. Pickle\n" +
                            "5. Cheese\n" +
                            "6. Mayo");

                     int ingredientString = int.Parse(Console.ReadLine());

                     switch (ingredientString)
                     {
                         case 1:
                            menuItem.IngredientList.Add(Ingredients.Lettuce);
                            Console.Clear();
                             break;
                         case 2:
                            menuItem.IngredientList.Add(Ingredients.Tomato);
                            break;
                         case 3:
                            menuItem.IngredientList.Add(Ingredients.Onion);
                            break;
                         case 4:
                            menuItem.IngredientList.Add(Ingredients.Pickle);
                            break;
                         case 5:
                            menuItem.IngredientList.Add(Ingredients.Cheese);
                            break;
                         case 6:
                            menuItem.IngredientList.Add(Ingredients.Mayo);
                            break;
                         default:
                             break;
                     }
                }
                if (inputNeedIng == "n" || inputNeedIng == "N" )
                {
                    hasAllIngredients = true;
                }
            }

            Console.WriteLine("Enter the price of them item.");
            menuItem.MealPrice = decimal.Parse(Console.ReadLine());

            _MenuRepo.AddMenuItem(menuItem);

        }
        private void RemoveItemFromMenu()
        {
            ViewAllMenuItems();
            Console.WriteLine("Enter the menu item number to be removed.");

            int input = int.Parse(Console.ReadLine());
            bool wasDeleted = _MenuRepo.DeleteMenuItem(input);

            if (wasDeleted)
            {
                Console.WriteLine("You have removed the menu item.");
            }
            else
            {
                Console.WriteLine("The menu item was not deleted.");
            }
        }

        private void Seed()
        {
            MenuItem chicken = new MenuItem(1, "Chicken Sandwich",
                                                 new List<Ingredients>
                                                 {
                                                     Ingredients.Lettuce,
                                                     Ingredients.Mayo,
                                                     Ingredients.Tomato
                                                 },
                                                 "Grilled filet on toasted bun",
                                                 11.95m);

            MenuItem burger = new MenuItem(2, "Cheeseburger",
                                                new List<Ingredients>
                                                 {
                                                     Ingredients.Cheese,
                                                     Ingredients.Lettuce,
                                                     Ingredients.Mayo,
                                                     Ingredients.Tomato,
                                                     Ingredients.Onion,
                                                     Ingredients.Pickle,
                                                 },
                                                "Half pound pattie on toasted bun",
                                                12.95m);

            MenuItem steak = new MenuItem(3, "French Dip",
                                                new List<Ingredients>
                                            {
                                                Ingredients.Cheese,
                                                Ingredients.Lettuce,
                                                Ingredients.Tomato
                                            },
                                                "Shaved beef on hoagie bun",
                                                14.95m);
            MenuItem mushroom = new MenuItem(4, "Portobello Sandwich",
                                                 new List<Ingredients>
                                                 {
                                                     Ingredients.Lettuce,
                                                     Ingredients.Mayo,
                                                     Ingredients.Tomato,
                                                     Ingredients.Onion,
                                                     Ingredients.Pickle,
                                                 },
                                                "Grilled and served on toasted bun",
                                                 10.95m);

            _MenuRepo.AddMenuItem(chicken);
            _MenuRepo.AddMenuItem(burger);
            _MenuRepo.AddMenuItem(steak);
            _MenuRepo.AddMenuItem(mushroom);
        }

        private void DisplayItem(MenuItem item)
        {
            Console.WriteLine($"{item.MealNumber}. {item.MealName} - {item.MealDescription}");

            foreach (var ingredient in item.IngredientList)
            {
                Console.WriteLine(ingredient);
            }

            Console.WriteLine($"${ item.MealPrice}");
        }
    }
}
