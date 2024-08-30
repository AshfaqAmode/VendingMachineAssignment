using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineAssignment.Business_Logic_Layer;
using static System.Windows.Forms.LinkLabel;

namespace VendingMachineAssignment
{
    public interface IDbOperations
    {
        SqlConnection GetConnection();
        void WriteDatabase(string query);
        int ReadDatabaseRecord(string query);
        List<Ingredients> GetIngredientsList(string query);
        List<Drinks> GetFullDrinksList(string query);
        void UpdateIngredientStockDB(List<Ingredients> ingredientList);

    }


    public class DbOperations : IDbOperations
    {
        //DB open and close with exception handling
        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(Constant.connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening connection: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
            return connection;
        }
        
        
        //uses SqlCommand to update the database depending on parameter (query)
        public void WriteDatabase(string query)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand a = new SqlCommand(query, conn);
                try
                {
                    a.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    MessageBox.Show("Error writing to database: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }


        //reads a record from database
        public int ReadDatabaseRecord(string query)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand a = new SqlCommand(query, conn);
                try
                {                    
                    SqlDataReader rdr = a.ExecuteReader();
                    rdr.Read();
                    return rdr.GetInt32(0);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error reading from database: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }


        //populates a list(type ingredients) from ingredients table
        public List<Ingredients> GetIngredientsList(string query)
        {
            List<Ingredients> ingredients = new List<Ingredients>();
            IDbOperations conn = new DbOperations();

            using (SqlCommand a = new SqlCommand(query, conn.GetConnection()))
            {
                SqlDataReader dr = a.ExecuteReader();
                while (dr.Read())
                {
                    Ingredients ingredient = new Ingredients
                    (
                   dr.GetInt32(dr.GetOrdinal("IngredientId")), // Get IngredientId as int
                   dr.GetString(dr.GetOrdinal("IngredientName")), // Get IngredientName as string
                   dr.GetInt32(dr.GetOrdinal("IngredientStock")) // Get IngredientStock as string
                    );

                    // Add the Ingredients object to the list
                    ingredients.Add(ingredient);
                }
            }
            return ingredients;
        }


        //populates a list(type drinks) from drinks table left join drinksIngredients table to get the ingredients for each drink
        public List<Drinks> GetFullDrinksList(string query)
        {
            List<Drinks> drinks = new List<Drinks> ();

            IDbOperations conn = new DbOperations();
            using (SqlCommand a = new SqlCommand(query, conn.GetConnection()))
            {
                SqlDataReader dr = a.ExecuteReader();
                while (dr.Read())
                {
                    var drinkId = dr.GetInt32(dr.GetOrdinal("DrinkId"));
                    var drinkName = dr.GetString(dr.GetOrdinal("DrinkName"));
                    int drinkPrice = dr.GetInt32(dr.GetOrdinal("DrinkPrice"));
                    int ingredientId = dr.GetInt32(dr.GetOrdinal("IngredientId"));
                     var drinkExists = (drinks.Exists(x => x.DrinkId == drinkId));
                    
                    if (!drinkExists)
                    {
                        Drinks newDrink = new Drinks
                        (
                            drinkId,
                            drinkName,
                            drinkPrice
                        );
                        newDrink.IngredientId.Add(ingredientId);
                        drinks.Add(newDrink);
                    }
                    else
                    {
                        var existingDrink = drinks.First(x => x.DrinkId == drinkId);
                        existingDrink.IngredientId.Add(ingredientId);
                    }
                }
            }
            return drinks;
        }


        //Updates Ingredient Stock in the database based on flag of ingredient obj
        public void UpdateIngredientStockDB(List<Ingredients> ingredientList)
        {
            IDbOperations conn = new DbOperations();
            var changedIngredientsList = ingredientList.Where(i => i.Changed).ToList();

            using (conn.GetConnection())
            {
                foreach (Ingredients ingredient in changedIngredientsList)
                {
                    using (var cmd = new SqlCommand("UPDATE Ingredients SET IngredientStock = @Stock WHERE IngredientId = @Id", conn.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@Stock", ingredient.IngredientStock);
                        cmd.Parameters.AddWithValue("@Id", ingredient.IngredientId);

                        cmd.ExecuteNonQuery();
                    }

                    ingredient.Changed = false;
                }
            }
        }
    }

}
