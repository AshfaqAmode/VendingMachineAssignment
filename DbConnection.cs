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
    }


    public class DbConnection : IDbConnection
    {
        private readonly string _connectionString = @"Data Source=localhost;Initial Catalog=VendingMachine;Integrated Security=True;Trust Server Certificate=True";

        public SqlConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

    }

    public class DbQuery
    {
        public SqlCommand ExecuteQuery(string query, SqlConnection connection)
        {
            var command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("git");
            return command;
        }
    }



}
