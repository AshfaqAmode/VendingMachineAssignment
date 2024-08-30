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
    internal class DrinkOperations
    {

        
        //checks if user can afford the drinkSelected, then removes its price from the balance
        public bool PurchaseDrink(string drinkSelected,ref int balance, List<Drinks> drinksList)
        {
            bool canPurchase = false;

            int currentbalance = balance;

            // Find the drink that matches the selection and is affordable
            var drinkToPurchase = drinksList.FirstOrDefault(drink => drink.DrinkName == drinkSelected && drink.DrinkPrice <= currentbalance);

            if (drinkToPurchase != null)
            {
                // Deduct the price from the balance
                balance -= drinkToPurchase.DrinkPrice;
                canPurchase = true; // Purchase was successful
            }

            return canPurchase; // No matching drink or not affordable
        }


    }
}
