using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Gold_Badge_Challenges_Komodo_Cafe
{
    public enum Ingredients
    {
        Lettuce = 1,
        Tomato,
        Onion,
        Pickle,
        Cheese,
        Mayo
    }

    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<Ingredients> IngredientList { get; set; } = new List<Ingredients>();
        public decimal MealPrice { get; set; }

        public MenuItem()
        {

        }

        public MenuItem(int mealNumber, string mealName, string mealDescription, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealPrice = mealPrice;

        }

        public MenuItem(int mealNumber, string mealName, List<Ingredients> ingredientList, string mealDescription, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            IngredientList = ingredientList;
            MealDescription = mealDescription;
            MealPrice = mealPrice;

        }
        public MenuItem(int mealNumber, string mealName, string mealDescription, List<Ingredients> ingredientList, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            IngredientList = ingredientList;
            MealDescription = mealDescription;
            MealPrice = mealPrice;

        }
    }
}
