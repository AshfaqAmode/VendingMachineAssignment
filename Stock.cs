using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineAssignment.Business_Logic_Layer;

namespace VendingMachineAssignment
{
    internal class Stock
    {

        //adds 10 to all ingredients then update database
        public void RestockAll(List<Ingredients>ingredientsList)
        {
            IDbOperations conn = new DbOperations();

            foreach(Ingredients ingredient in ingredientsList)
            {
                ingredient.IngredientStock += 10;
                ingredient.Changed = true;
            }

            conn.UpdateIngredientStock(ingredientsList);
        }

        public void CheckStock()
        {


        }

    }

}
