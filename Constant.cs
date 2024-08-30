using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment
{
    public class Constant
    {
        public const string selectDrinksQuery = "SELECT * FROM Drinks";
        public const string selectIngredientsQuery = "SELECT * FROM Ingredients";
        public const string selectDrinksIngredientsQuery = "SELECT * FROM DrinkIngredients";
        public const string selectLeftJoinDrinksIngredientsQuery = "SELECT Drinks.DrinkID, Drinks.DrinkName, Drinks.DrinkPrice, DrinkIngredients.IngredientID FROM Drinks LEFT JOIN DrinkIngredients ON Drinks.DrinkID = DrinkIngredients.DrinkID;";
        public const string connectionString = @"data source=Dayforce20ZptW6;initial catalog=VendingMachine;trusted_connection=true";
        public enum Drink
        {
            Tea = 1,
            Cappuccino = 2,
            Mochaccino = 3,
            HotChocolate = 4,
            Milk = 5
        }

        public enum Ingredient
        {
            Milk = 1,
            Tea = 2,
            Coffee = 3,
            Chocolate = 4,
            Sugar = 5
        }


    }
}
