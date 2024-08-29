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
    interface IStockDisplay
    {
        int ReturnStockAmount(string a);
    }

    internal class DisplayStock 
    {
        public bool CheckStockAmount(List<Ingredients> ingredientList)
        {
            bool stockMissing = false;

            stockMissing =  ingredientList.Any(ingredient => ingredient.IngredientStock <= 0);

            return stockMissing;
        }
    }
}
