using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Gold_Badge_Challenges_Komodo_Cafe
{
    public class KomodoMenuRepo
    {
        private readonly List<MenuItem> menuItems = new List<MenuItem>();

        //Create
        public void AddMenuItem(MenuItem items)
        {
            menuItems.Add(items);
        }

        //Read
        public List<MenuItem> ViewMenuItem()
        {
            return menuItems;
        }

        //Update
       /* public bool UpdateMenuItem(string menuItemName, MenuItem newItem)
        {
            MenuItem oldItem = GetMenuItem(menuItemName);
            if (oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealName = newItem.MealName;
                oldItem.MealDescription = newItem.MealDescription;
                oldItem.IngredientList = newItem.IngredientList;
                oldItem.MealPrice = newItem.MealPrice;
                return true;
            }
            else
            {
                return false;
            }
        }*/

        //Delete
        public bool DeleteMenuItem(int menuItemNumber)
        {
            MenuItem item = GetMenuItemByNumber(menuItemNumber);
            if (item == null)
            {
                return false;
            }
            int initialCount = menuItems.Count;
            menuItems.Remove(item);

            if (initialCount > menuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       

        //Helper
        public MenuItem GetMenuItemByNumber(int menuItemNumber)
        {
            foreach (MenuItem item in menuItems)
            {
                if (item.MealNumber == menuItemNumber)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
