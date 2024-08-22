using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VendingMachineAssignment
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        public void showdata()
        {
            IDbConnection conn = new DbConnection();
            conn.GetConnection();
            string query = "SELECT * FROM Drinks";
            DbQuery LoadDrinks = new DbQuery();
            LoadDrinks.ExecuteQuery(query, conn.GetConnection());
            DataTable dt = new DataTable();
            LoadDrinks.Fill(LoadDrinks.ExecuteQuery(query, conn.GetConnection()));
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
