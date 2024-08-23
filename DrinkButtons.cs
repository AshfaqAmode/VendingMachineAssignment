using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public bool PurchaseDrink(string drink,ref int balance)
        {
            int drinkPrice;
            IDbConnection a = new DbAccess();
            drinkPrice = a.GetDrinkPrice($"SELECT DrinkPrice FROM Drinks WHERE DrinkName = '{drink}'");


            if (balance >= drinkPrice)
            {
                balance -= drinkPrice;
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}
