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
    }


    public class DbConnection : IDbConnection
    {
        private readonly string _connectionString = @"data source=Dayforce20ZptW6;initial catalog=VendingMachine;trusted_connection=true";

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

    }

}
