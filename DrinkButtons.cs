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
        public void TakeDrinkIngredients(string removeIngredients)
        {
            IDbConnection conn = new DbAccess();
            conn.WriteDatabase($"UPDATE Ingredients SET IngredientStock = IngredientStock - 1 WHERE IngredientName = '{removeIngredients}'");
        }
        
        //retrieves drink price
        public bool PurchaseDrink(string drink,ref int balance)
        {
            int drinkPrice;
            IDbConnection a = new DbAccess();
            drinkPrice = a.GetDrinkPrice(drink);

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
