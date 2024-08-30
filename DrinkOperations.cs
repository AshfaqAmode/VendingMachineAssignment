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
    internal class DrinkOperations
    {

        //removes one from the ingredient object's stock, then updates database.
        public void TakeDrinkIngredients(string drinkSelected, List<Drinks> drinksList, List<Ingredients> ingredientsList)
        {
            IDbOperations conn = new DbOperations();

            var drink = drinksList.FirstOrDefault(d => d.DrinkName == drinkSelected);
            var ingredientsNeeded = drink.IngredientId;

            if (drink != null)
            {
                foreach (var ingredientId in ingredientsNeeded)
                {
                    var ingredient = ingredientsList.FirstOrDefault(i => i.IngredientId == ingredientId);
                    if (ingredient != null)
                    {
                        ingredient.IngredientStock -= 1;
                        ingredient.Changed = true;
                    }
                }
            }
            conn.UpdateIngredientStockDB(ingredientsList);
        }

        
        //checks if user can afford the drinkSelected, then removes its price from the balance
        public bool PurchaseDrink(string drinkSelected,ref int balance, List<Drinks> drinksList)
        {
            bool canPurchase = false;

            foreach(var drink in drinksList)
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
