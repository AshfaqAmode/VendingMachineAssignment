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

        public void PopulateStock()
        {
            IStockDisplay stockValue = new DisplayStock();
            TeaStockTextBox.Text = $"{stockValue.ReturnStockAmount("Tea")}";
            SugarStockTextBox.Text = $"{stockValue.ReturnStockAmount("Sugar")}";
            MilkStockTextBox.Text = $"{stockValue.ReturnStockAmount("Milk")}";
            ChocolateStockTextBox.Text = $"{stockValue.ReturnStockAmount("Chocolate")}";
            CoffeeStockTextBox.Text = $"{stockValue.ReturnStockAmount("Coffee")}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateStock();


        }

        private void RestockButton_Click(object sender, EventArgs e)
        {
            Restock restock = new Restock();
            restock.RestockAll();
            PopulateStock();
        }
    }
}
