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
    public interface IDbConnection
    {
        SqlConnection GetConnection();
        void WriteDatabase(string query);
        int ReadDatabaseField(string query);
        DataTable ReadDatabaseRow(string query);
        List<Ingredients> GetIngredientsList(string query);
        List<Drinks> GetFullDrinksList(string query);
        int GetDrinkPrice(string a);
        int ReturnStockAmount(string a);
        int CheckStockAmount();

    }


    public class DbAccess : IDbConnection
    {
        //DB open and close with exception ahndling
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

        //Created ReadDatabase function
        public int ReadDatabaseField(string query)
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

        public DataTable ReadDatabaseRow(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            using (SqlConnection conn = GetConnection())
            {
                adapter.SelectCommand = new SqlCommand(query, conn);
                try
                {
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error writing to database: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return dt;
                }
                
            }
        }

        public List<Ingredients> GetIngredientsList(string query)
        {
            List<Ingredients> ingredients = new List<Ingredients>();
            IDbConnection conn = new DbAccess();

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

        public List<Drinks> GetFullDrinksList(string query)
        {
            List<Drinks> drinks = new List<Drinks> ();

            IDbConnection conn = new DbAccess();
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

        //return stock amount -- now redundant with ingrdient object
        public int ReturnIngredientStockAmount(string a)
        {
            IDbConnection conn = new DbAccess();
            conn.GetConnection();
            string query = $"SELECT IngredientStock FROM Ingredients WHERE IngredientName = '{a}'";

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

        //now redundant with ingredient obj
        public int CheckStockAmount()
        {
            IDbConnection conn = new DbAccess();
            conn.GetConnection();
            string query = $"SELECT IngredientStock FROM Ingredients";
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            SqlDataReader rdr = cmd.ExecuteReader();

            try
            {
                rdr.Read();
                int data = rdr.GetInt32(0);
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
                return 0;
            }
        }

        public int ReturnStockAmount(string a)
        {
            throw new NotImplementedException();
        }
    }

}
