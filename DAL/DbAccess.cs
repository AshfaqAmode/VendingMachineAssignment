using System;
using System.Collections.Generic;
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
        SqlConnection CloseConnection();
        void WriteDatabase(string query);
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
        public SqlConnection CloseConnection()
        {
            var connection = new SqlConnection(Constant.connectionString);
            connection.Open();
            connection.Close();
            return connection;
        }

        public void WriteDatabase(string query)
        {
            IDbConnection conn = new DbAccess();
            using (conn.GetConnection())
            {
                SqlCommand a = new SqlCommand(query, conn.GetConnection());
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

        //returns drink price (int)
        public int GetDrinkPrice(string drink)
        {
            IDbConnection conn = new DbAccess();
            int price;

            try
            {
                conn.GetConnection(); // Ensure the connection is opened
                using (SqlCommand cmd = new SqlCommand($"SELECT DrinkPrice FROM Drinks WHERE DrinkName = '{drink}'", conn.GetConnection()))
                {
                    // ExecuteScalar is used to fetch a single value from the database
                    object result = cmd.ExecuteScalar();

                    // Check if result is not null and convert to int
                    if (result != null && int.TryParse(result.ToString(), out price))
                    {
                        return price;
                    }
                    else
                    {
                        // Handle the case where the result is null or not a valid integer
                        throw new Exception("Invalid result from query.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them or rethrow)
                Console.WriteLine("Error: " + ex.Message);
                throw; // Re-throw the exception after logging it
            }
            finally
            {
                conn.CloseConnection(); // Ensure the connection is closed
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
