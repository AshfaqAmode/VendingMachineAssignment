using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineAssignment.Business_Logic_Layer;

namespace VendingMachineAssignment
{
    internal class DrinkButtons
    {

        //removes one from the ingredient object's stock, then updates database.
        public void TakeDrinkIngredients(string removeIngredients, List<Ingredients> ingredientsList)
        {
            IDbOperations conn = new DbOperations();

            foreach (var ingredient in ingredientsList)
            {
                if (ingredient.IngredientName == removeIngredients)
                {
                    ingredient.IngredientStock -= 1;
                    ingredient.Changed = true;
                }
            }

            conn.UpdateIngredientStockDB(ingredientsList);
        }

        
        //checks if user can afford the drinkSelected, then removes its price from the balance
        public bool PurchaseDrink(string drinkSelected,ref int balance, List<Drinks> drinks)
        {
            bool canPurchase = false;

            foreach(var drink in drinks)
            {
                if (drink.DrinkName == drinkSelected && drink.DrinkPrice <= balance)
                {
                    balance -= drink.DrinkPrice;
                    canPurchase = true;
                }
            }

            return canPurchase;

            /*
            // Find the drink that matches the selection and is affordable
            var drinkToPurchase = drinks
                .FirstOrDefault(drink => drink.DrinkName == drinkSelected && drink.DrinkPrice <= balance);

            if (drinkToPurchase != null)
            {
                // Deduct the price from the balance
                balance -= drinkToPurchase.DrinkPrice;
                return true; // Purchase was successful
            }

            return false; // No matching drink or not affordable*/
        }


    }
}
