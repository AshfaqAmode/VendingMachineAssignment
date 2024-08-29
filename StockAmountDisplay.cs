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

        //returns stock amount of specified ingredient
        public int ReturnStockAmount(string a)
        {
            IDbConnection conn = new DbOperations();
            string query = $"SELECT IngredientStock FROM Ingredients WHERE IngredientName = '{a}'";

            //SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            using (SqlCommand cmd = new SqlCommand(query, conn.GetConnection()))
            {
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int data = rdr.GetInt32(0);
                    return data;

                }
                else
                {
                    MessageBox.Show("Unable to read stock amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

            }
        }

        public bool CheckStockAmount(List<Ingredients> ingredientList)
        {
            bool stockMissing = false;

            stockMissing =  ingredientList.Any(ingredient => ingredient.IngredientStock <= 0);

            return stockMissing;
        }
    }
}
