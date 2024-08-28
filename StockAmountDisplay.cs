using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineAssignment
{
    interface IStockDisplay
    {
        int ReturnStockAmount(string a);
    }

    internal class DisplayStock 
    {

        //returns stock amount of specified ingredient
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

        public bool CheckStockAmount()
        {
            IDbConnection conn = new DbAccess();
            int data;
            data = conn.ReadDatabase($"SELECT IngredientStock FROM Ingredients");
            if ( data > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("One or more items need to be restocked!");
                return false;
            }
            //conn.GetConnection();
            //string query = $"SELECT IngredientStock FROM Ingredients";
            //SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            //SqlDataReader rdr = cmd.ExecuteReader();

            //if (rdr.Read())
            //{

            //    int data = rdr.GetInt32(0);
            //    if (data <= 0)
            //    {
            //        conn.CloseConnection();
            //        return false;
            //    }
            //    else
            //    {
            //        conn.CloseConnection();
            //        return true;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Unable to read stock amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    conn.CloseConnection();
            //    return false;
            //}
        }
    }

   //Previous implementation (inefficient) so changed to one function where ingredient name is passed as param

    //interface IStockDisplay
    //{
    //    int ShowData();
    //}

    //internal class TeaStockDisplay : IStockDisplay
    //{
    //    public int ShowData()
    //    {
    //        IDbConnection conn = new DbConnection();
    //        conn.GetConnection();
    //        string query = "SELECT IngredientStock FROM Ingredients WHERE IngredientName = 'Tea'";

    //        SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
    //        SqlDataReader rdr = cmd.ExecuteReader();

    //        if (rdr.Read())
    //        {
    //            int data = rdr.GetInt32(0);

    //            conn.CloseConnection();
    //            return data;

    //        }
    //        else
    //        {
    //            Console.WriteLine("did not read");

    //            conn.CloseConnection();
    //            return 0;
    //        }
    //    }
    //}

    //internal class MilkStockDisplay : IStockDisplay
    //{
    //    public int ShowData()
    //    {
    //        IDbConnection conn = new DbConnection();
    //        conn.GetConnection();
    //        string query = "SELECT IngredientStock FROM Ingredients WHERE IngredientName = 'Milk'";

    //        SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
    //        SqlDataReader rdr = cmd.ExecuteReader();

    //        if (rdr.Read())
    //        {
    //            int data = rdr.GetInt32(0);

    //            conn.CloseConnection();
    //            return data;

    //        }
    //        else
    //        {
    //            Console.WriteLine("did not read");

    //            conn.CloseConnection();
    //            return 0;
    //        }
    //    }
    //}

    //internal class CoffeeStockDisplay : IStockDisplay
    //{
    //    public int ShowData()
    //    {
    //        IDbConnection conn = new DbConnection();
    //        conn.GetConnection();
    //        string query = "SELECT IngredientStock FROM Ingredients WHERE IngredientName = 'Coffee'";

    //        SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
    //        SqlDataReader rdr = cmd.ExecuteReader();

    //        if (rdr.Read())
    //        {
    //            int data = rdr.GetInt32(0);

    //            conn.CloseConnection();
    //            return data;

    //        }
    //        else
    //        {
    //            Console.WriteLine("did not read");

    //            conn.CloseConnection();
    //            return 0;
    //        }
    //    }
    //}

    //internal class ChocolateStockDisplay : IStockDisplay
    //{
    //    public int ShowData()
    //    {
    //        IDbConnection conn = new DbConnection();
    //        conn.GetConnection();
    //        string query = "SELECT IngredientStock FROM Ingredients WHERE IngredientName = 'Chocolate'";

    //        SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
    //        SqlDataReader rdr = cmd.ExecuteReader();

    //        if (rdr.Read())
    //        {
    //            int data = rdr.GetInt32(0);

    //            conn.CloseConnection();
    //            return data;

    //        }
    //        else
    //        {
    //            Console.WriteLine("did not read");

    //            conn.CloseConnection();
    //            return 0;
    //        }
    //    }
    //}

    //internal class SugarStockDisplay : IStockDisplay
    //{
    //    public int ShowData()
    //    {
    //        IDbConnection conn = new DbConnection();
    //        conn.GetConnection();
    //        string query = "SELECT IngredientStock FROM Ingredients WHERE IngredientName = 'Sugar'";

    //        SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
    //        SqlDataReader rdr = cmd.ExecuteReader();

    //        if (rdr.Read())
    //        {
    //            int data = rdr.GetInt32(0);
    //            conn.CloseConnection();
    //            return data;

    //        }
    //        else
    //        {
    //            Console.WriteLine("did not read");

    //            conn.CloseConnection();
    //            return 0;
    //        }
    //    }
    //}







}
