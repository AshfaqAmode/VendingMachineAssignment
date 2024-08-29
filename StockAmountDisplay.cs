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
    }

    internal class StockOperations : IStockOperations
    {
        public bool CheckStockAmount(List<Ingredients> ingredientList)
        {
            bool stockMissing = false;

            stockMissing =  ingredientList.Any(ingredient => ingredient.IngredientStock <= 0);

            return stockMissing;
        }

        public void RemoveStock(string selectedDrink, List<Ingredients> ingredientList, List<Drinks> drinkList)
        {
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
    }
}
