using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment.Business_Logic_Layer
{
    public class Ingredients
    {
        private int _ingredientId;
        private string _ingredientName;
        private int _ingredientStock;

        public Ingredients(int ingredientId, string ingredientName, int ingredientStock)
        {
            IngredientId = ingredientId;
            IngredientName = ingredientName;
            IngredientStock = ingredientStock;
        }

        public int IngredientId { get => _ingredientId; set => _ingredientId = value; }
        public string IngredientName { get => _ingredientName; set => _ingredientName = value; }
        public int IngredientStock { get => _ingredientStock; set => _ingredientStock = value; }

        //public  List<Ingredients> CreateIngredientList(string query)
        //{
        //    List<Ingredients> ingredients = new List<Ingredients>();
        //    IDbConnection conn = new DbAccess();

        //    SqlCommand a = new SqlCommand(query, conn.GetConnection());
        //    SqlDataReader dr = a.ExecuteReader(); // Fill in what is needed, can't remember offhand

        //    while (dr.Read())
        //    {
        //        Ingredients ingredient = new Ingredients(
        //           dr.GetInt32(dr.GetOrdinal("IngredientId")), // Get IngredientId as int
        //           dr.GetString(dr.GetOrdinal("IngredientName")), // Get IngredientName as string
        //           dr.GetString(dr.GetOrdinal("IngredientStock")) // Get IngredientStock as string
        //       );

        //        // Add the Ingredients object to the list
        //        ingredients.Add(ingredient);
        //    }
        //    return ingredients;
        //}
    }
}
