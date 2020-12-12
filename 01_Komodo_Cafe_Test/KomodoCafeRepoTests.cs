using _01_Gold_Badge_Challenges_Komodo_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_Komodo_Cafe_Test
{
    [TestClass]
    public class KomodoCafeRepoTests
    {
        private KomodoMenuRepo _cafeRepo;
        private MenuItem _menuItem;

        [TestInitialize]
        public void Arrange()
        {
            _cafeRepo = new KomodoMenuRepo();
            _menuItem = new MenuItem(5, "Spicy Chicken", new List<Ingredients> { Ingredients.Lettuce, Ingredients.Mayo, Ingredients.Tomato}, "Fried filet", 14.95m);

            _cafeRepo.AddMenuItem(_menuItem);
        }

        [TestMethod]
        public void AddToMenu()
        {
            int expected = 1;
            List<MenuItem> items = _cafeRepo.ViewMenuItem();
            int actual = items.Count;
            //Assert-------
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteFromMenu()
        {
            //Act
            bool deleteItem = _cafeRepo.DeleteMenuItem(_menuItem.MealNumber);

            //Assert
            Assert.IsTrue(deleteItem);
        }

        [TestMethod]
        public void MyTestMethod_GetMenuItemByNumber()
        {
            int expected = 5;
            MenuItem menuItem = _cafeRepo.GetMenuItemByNumber(5);
            Assert.AreEqual(expected, menuItem.MealNumber);
        }
    }
}
