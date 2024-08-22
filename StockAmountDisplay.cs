﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment
{
    interface IStockDisplay
    {
        int ReturnStockAmount(string a);
    }

    internal class DisplayStock : IStockDisplay
    {
        public int ReturnStockAmount(string a)
        {
            IDbConnection conn = new DbConnection();
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
                Console.WriteLine("did not read");

                conn.CloseConnection();
                return 0;
            }
        }
    }


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
