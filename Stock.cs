using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment
{
    internal class Stock
    {

        //adds 10 to all ingredients
        public void RestockAll()
        {
            IDbConnection conn = new DbOperations();
            conn.WriteDatabase("UPDATE Ingredients SET IngredientStock = IngredientStock + 10");
        }

        public void CheckStock()
        {


        }

    }

}
