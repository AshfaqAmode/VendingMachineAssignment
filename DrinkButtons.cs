using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment
{
    internal class DrinkButtons
    {

        //removes one from the 
        public void TakeDrink(string removeIngredients)
        {
            IDbConnection conn = new DbAccess();
            conn.GetConnection();
            string query = $"UPDATE Ingredients SET {removeIngredients}";
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            cmd.ExecuteNonQuery();
            conn.CloseConnection();

        }

        //retrieves drink pric
        public void PurchaseDrink(string drink)
        {
            int drinkPrice;
            IDbConnection a = new DbAccess();
            int drinkprice = a.ExecuteBuyQuery($"SELECT DrinkPrice FROM Drinks WHERE DrinkName = '{drink}'");
            

        }

    }
}
