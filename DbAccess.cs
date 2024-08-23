using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment
{
    public interface IDbConnection
    {
        SqlConnection GetConnection();
        SqlConnection CloseConnection();
        int ExecuteBuyQuery(string a);
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
        public int ExecuteBuyQuery(string query)
        {
            IDbConnection conn = new DbAccess();
            conn.GetConnection();
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            cmd.ExecuteNonQuery();
            conn.CloseConnection();
            return cmd.ExecuteNonQuery();
        }


    }

}
