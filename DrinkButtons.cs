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

        //removes one from the 
        public void TakeDrinkIngredients(string removeIngredients, List<Ingredients> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                if (ingredient.IngredientName == removeIngredients)
                {
                    ingredient.IngredientStock -= 1;
                }
            }
        }
        
        //retrieves drink price
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
        }


    }
}
