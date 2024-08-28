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
            IDbConnection conn = new DbAccess();
            conn.WriteDatabase("UPDATE Ingredients SET IngredientStock = IngredientStock + 10");
            conn.CloseConnection();
        }

        public void CheckStock()
        {


        }

    }

}
