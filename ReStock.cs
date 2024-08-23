using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment
{
    internal class Restock
    {

        //adds 10 to all ingredients
        public void RestockAll()
        {
            IDbConnection conn = new DbAccess();
            conn.GetConnection();
            string query = $"UPDATE Ingredients SET IngredientStock = IngredientStock + 10";
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            cmd.ExecuteNonQuery();
            conn.CloseConnection();
        }

    }

}
