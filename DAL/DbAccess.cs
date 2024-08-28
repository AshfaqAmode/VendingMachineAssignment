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

namespace VendingMachineAssignment
{
    public interface IDbConnection
    {
        SqlConnection GetConnection();
        void CloseConnection();
        void WriteDatabase(string query);
        int ReadDatabaseField(string query);
        DataSet ReadDatabaseColumn(string query);
        List<Ingredients> CreateIngredientList(string query);
        int GetDrinkPrice(string a);
        int ReturnStockAmount(string a);

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
        /*
        public void CloseConnection(SqlConnection connection)
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
        */
        
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
                    MessageBox.Show("Error writing to database: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        public DataSet ReadDatabaseColumn(string query)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            using (SqlConnection conn = GetConnection())
            {
                adapter.SelectCommand = new SqlCommand(query, conn);
                try
                {
                    adapter.Fill(ds);
                    return ds;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error writing to database: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ds;
                }
            }
        }

        public List<Ingredients> CreateIngredientList(string query)
        {
            List<Ingredients> ingredients = new List<Ingredients>();
            IDbConnection conn = new DbAccess();

            SqlCommand a = new SqlCommand(query, conn.GetConnection());
            SqlDataReader dr = a.ExecuteReader(); // Fill in what is needed, can't remember offhand

            while (dr.Read())
            {
                Ingredients ingredient = new Ingredients(
                   dr.GetInt32(dr.GetOrdinal("IngredientId")), // Get IngredientId as int
                   dr.GetString(dr.GetOrdinal("IngredientName")), // Get IngredientName as string
                   dr.GetString(dr.GetOrdinal("IngredientStock")) // Get IngredientStock as string
                 );

                // Add the Ingredients object to the list
                ingredients.Add(ingredient);
            }
            return ingredients;
        }


        //returns drink price (int)
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

        //return stock amount
        public int ReturnStockAmount(string a)
        {
            IDbConnection conn = new DbAccess();
            conn.GetConnection();
            string query = $"SELECT IngredientStock FROM Ingredients WHERE IngredientName = '{a}'";

            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                int data = rdr.GetInt32(0);
                conn.CloseConnection();
                return data;

            }
            else
            {
                MessageBox.Show("Unable to read stock amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.CloseConnection();
                return 0;
            }
        }

        //
        public bool CheckStockAmount()
        {
            IDbConnection conn = new DbAccess();
            conn.GetConnection();
            string query = $"SELECT IngredientStock FROM Ingredients";
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {

                int data = rdr.GetInt32(0);
                if (data <= 0)
                {
                    conn.CloseConnection();
                    return false;
                }
                else
                {
                    conn.CloseConnection();
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Unable to read stock amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.CloseConnection();
                return false;
            }
        }

    }

}
