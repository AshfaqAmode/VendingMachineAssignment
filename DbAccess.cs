using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment
{
    public interface IDbConnection
    {
        SqlConnection GetConnection();
        SqlConnection CloseConnection();
        int GetDrinkPrice(string a);
        
    }


    public class DbAccess : IDbConnection
    {
        //private readonly so conn string cant be changed and it cant be accessed outside the class and file 
        private readonly string _connectionString = @"data source=Dayforce20ZptW6;initial catalog=VendingMachine;trusted_connection=true";

        //DB open and close within a function
        public SqlConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
        public SqlConnection CloseConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Close();
            return connection;
        }

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



    }

}
