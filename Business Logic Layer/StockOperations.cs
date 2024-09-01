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
        bool CheckAllStockAmount(List<Ingredients> ingredientList);
        void RestockAll(List<Ingredients> ingredientsList);
    }

    internal class StockOperations : IStockOperations
    {
        //check if any stock is 0 or less
        public bool CheckAllStockAmount(List<Ingredients> ingredientList)
        {
            bool stockMissing = false;

            if( ingredientList.All(ingredient => ingredient.IngredientStock <= 0))
            {
                stockMissing = true;
            }

            return stockMissing;
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
