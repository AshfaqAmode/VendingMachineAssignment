using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineAssignment.Business_Logic_Layer;

namespace VendingMachineAssignment
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            IDbConnection conn = new DbAccess();


            //List<Ingredients> b = conn.GetIngredientsList(Constant.selectIngredientsQuery);
            //print objects in drinks list
            List<Drinks> a = new List<Drinks>();
            a = conn.GetFullDrinksList(Constant.selectLeftJoinDrinksIngredientsQuery);
            foreach (var drink in a)
            {
                string ingredientidconcat = "";

                foreach (int ingredientId in drink.IngredientId)
                {
                    ingredientidconcat = ingredientidconcat + ingredientId.ToString();
                }

                MessageBox.Show($"{drink.DrinkName}, {drink.DrinkId}, {drink.DrinkPrice}, {ingredientidconcat}");
            }

            //print objects in ingredients list
            //List<Ingredients> b = conn.GetIngredientsList(Constant.selectIngredientsQuery);
            //foreach (var ingredient in b)
            //{
            //    MessageBox.Show($"{ingredient.IngredientId}, {ingredient.IngredientName}, {ingredient.IngredientStock}");
            //}

            //print objects in drinksingredients list
            //List<DrinksIngredients> c = conn.GetDrinksIngredientsList(selectDrinksIngredientsQuery);
            //foreach (var drinksIngredients in c)
            //{
            //    MessageBox.Show($"{drinksIngredients.DrinkId}, {drinksIngredients.IngredientId}");
            //}


            //testing readdatabaserow
            //DataTable Table = conn.ReadDatabaseRow("SELECT * FROM Ingredients WHERE IngredientId = 1");

            //foreach (DataRow dataRow in Table.Rows)
            //{
            //    foreach (var item in dataRow.ItemArray)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

        }
    }
}
