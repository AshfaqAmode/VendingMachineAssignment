using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment.Business_Logic_Layer
{
    public class Constant
    {
        public const string selectDrinksQuery = "SELECT * FROM Drinks";
        public const string selectIngredientsQuery = "SELECT * FROM Ingredients";
        public const string selectDrinksIngredientsQuery = "SELECT * FROM DrinkIngredients";
        public const string connectionString = @"data source=Dayforce20ZptW6;initial catalog=VendingMachine;trusted_connection=true";
    }
}
