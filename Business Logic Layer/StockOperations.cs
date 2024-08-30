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
    interface IStockOperations
    {
        bool CheckStockAmount(List<Ingredients> ingredientList);
        void RemoveStock(string selectedDrink, List<Ingredients> ingredientList, List<Drinks> drinkList);
        void RestockAll(List<Ingredients> ingredientsList);
    }

    internal class StockOperations : IStockOperations
    {
        //check if any stock is 0 or less
        public bool CheckStockAmount(List<Ingredients> ingredientList)
        {
            bool stockMissing = false;

            stockMissing =  ingredientList.Any(ingredient => ingredient.IngredientStock <= 0);

            return stockMissing;
        }


        //removes one from the stock of ingredients... ingredients identified by ingredientId list in drink obj
        public void RemoveStock(string selectedDrink, List<Ingredients> ingredientList, List<Drinks> drinkList)
        {
            IDbOperations conn = new DbOperations();
            var drink = drinkList.FirstOrDefault(d => d.DrinkName == selectedDrink);
            var ingredientsNeeded = drink.IngredientId;

            if (drink != null)
            {
                foreach (var ingredientId in ingredientsNeeded)
                {
                    var ingredient = ingredientList.FirstOrDefault(i => i.IngredientId == ingredientId);
                    if (ingredient != null)
                    {
                        ingredient.IngredientStock -= 1;
                        ingredient.Changed = true;
                    }
                }
            }
            
            
        }


        //adds 10 to all ingredients then update database
        public void RestockAll(List<Ingredients> ingredientsList)
        {
            IDbOperations conn = new DbOperations();

            foreach (Ingredients ingredient in ingredientsList)
            {
                ingredient.IngredientStock += 10;
                ingredient.Changed = true;
            }

            conn.UpdateIngredientStockDB(ingredientsList);

        }
    }
}
