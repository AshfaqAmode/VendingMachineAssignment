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

        public bool HasBalance(int balance,int drinkId, List<Drinks> drinksList)
        {
            var drinkToPurchase = drinksList.FirstOrDefault(drink => drink.DrinkId == drinkId);
            bool hasBalance = false;

            if (drinkToPurchase != null && balance >= drinkToPurchase.DrinkPrice)
            {
                hasBalance = true;
                return hasBalance;
            }
            else
            {
                return hasBalance;
            }
        }

        public bool HasStock(int drinkId, List<Drinks> drinksList, List<Ingredients> ingredientsList)
        {
            var drink = drinksList.FirstOrDefault(d => d.DrinkId == drinkId);
            var ingredientsNeeded = drink.IngredientIds;
            bool hasStock = false;

            foreach (int ingredentId in ingredientsNeeded)
            {
                if(ingredientsList.Any(ingredient => ingredient.IngredientId == ingredentId && ingredient.IngredientStock > 0))
                {
                    hasStock = true;
                }
                else
                {
                    hasStock = false;
                    return hasStock;
                }
            }

            return hasStock;
        }

        public int PayDrink(int drinkId, int balance, List<Drinks> drinksList)
        {
            var drinkToPurchase = drinksList.FirstOrDefault(drink => drink.DrinkId == drinkId);

            if (drinkToPurchase != null && balance >= drinkToPurchase.DrinkPrice)
            {
                balance -= drinkToPurchase.DrinkPrice;
            }

            return balance;
        }
    }
}
