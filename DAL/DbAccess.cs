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
        void CloseConnection();
        void CloseConnectionNew(SqlConnection connection);
        void WriteDatabase(string query);
        int ReadDatabaseField(string query);
        DataTable ReadDatabaseRow(string query);
        List<Ingredients> GetIngredientsList(string query);
        List<Drinks> GetDrinksList(string query);
        List<Drinks> GetDrinksIngredientIdList(string query);
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

        public void CloseConnection()
        {
            var connection = new SqlConnection(Constant.connectionString);
            connection.Open();
            connection.Close();
        }
        
        public void CloseConnectionNew(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                    Console.WriteLine("Connection closed successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error closing connection: " + ex.Message);
                }
            }
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
                CloseConnectionNew(conn);
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



        //ignore
        public List<Drinks> GetDrinksList(string query)
        {
            List<Drinks> drinks = new List<Drinks>();
            IDbConnection conn = new DbAccess();

            using (SqlCommand a = new SqlCommand(query, conn.GetConnection()))
            {
                SqlDataReader dr = a.ExecuteReader();
                while (dr.Read())
                {
                    Drinks drink = new Drinks(
                       dr.GetInt32(dr.GetOrdinal("DrinkId")), // Get IngredientId as int
                       dr.GetString(dr.GetOrdinal("DrinkName")), // Get IngredientName as string
                       dr.GetInt32(dr.GetOrdinal("DrinkPrice"))// Get IngredientStock as string
                     );

                    // Add the Ingredients object to the list
                    drinks.Add(drink);

                    
                }

            }

            return drinks;
        }

        //ignore
        public List<Drinks> GetDrinksIngredientIdList(string query)
        {
            List<Drinks> drinks = GetDrinksList(Constant.selectDrinksQuery);
            IDbConnection conn = new DbAccess();

            //SqlCommand a = new SqlCommand(query, conn.GetConnection());
            using (SqlCommand a = new SqlCommand(query, conn.GetConnection()))
            {
                SqlDataReader dr = a.ExecuteReader();
                while (dr.Read())
                {
                    foreach (var drink in drinks)
                    {
                        while (dr.Read())
                        {
                            if (drink.DrinkId == dr.GetInt32(dr.GetOrdinal("DrinkId")))
                            {
                                int CurrentIngredientId = dr.GetInt32(dr.GetOrdinal("IngredientId"));
                                drink.IngredientId.Add(CurrentIngredientId);
                            }
                        }
                        
                    }
                }
            }
            return drinks;

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
                    var drinkid = dr.GetInt32(dr.GetOrdinal("DrinkId"));

                    int IngredientId = dr.GetInt32(dr.GetOrdinal("IngredientId"));
                    if (!drinks.Exists(x => x.DrinkId == drinkid)) {
                        Drinks drink = new Drinks
                        (
                           drinkid, // Get IngredientId as int
                           dr.GetString(dr.GetOrdinal("DrinkName")), // Get IngredientName as string
                           dr.GetInt32(dr.GetOrdinal("DrinkPrice"))// Get IngredientStock as string
                        );
                        drink.IngredientId.Add(IngredientId);
                        drinks.Add(drink);
                    }
                    var drink = drinks.Where(x => x.DrinkId == drinkid) {drink.IngredientId.Add(IngredientId)}

                    //while (dr.GetInt32(dr.GetOrdinal("DrinkId")) == drink.DrinkId)
                    //{
                    //    int IngredientId = dr.GetInt32(dr.GetOrdinal("IngredientId"));
                    //    drink.IngredientId.Add(IngredientId);
                    //    dr.Read();
                    //}
                }
            }
            return drinks;
        }



        //returns drink price (int) -- now redundant with drink obj
        public int GetDrinkPrice(string drink)
        {
            IDbConnection conn = new DbAccess();
            int price;
            price = conn.ReadDatabaseField($"SELECT DrinkPrice FROM Drinks WHERE DrinkName = '{drink}'");
                            if (price > 0)
                            {
                                return price;
                            }
                            else
                            {
                                // Handle the case where the result is null or not a valid integer
                                throw new Exception("Invalid result from query.");
                            }

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
                    conn.CloseConnection();
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
