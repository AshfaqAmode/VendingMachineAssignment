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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            IStockDisplay stockObj = new DisplayStock();

            TeaStockTextBox.Text = $"{stockObj.ReturnStockAmount("Tea")}";
            SugarStockTextBox.Text = $"{stockObj.ReturnStockAmount("Sugar")}";
            MilkStockTextBox.Text = $"{stockObj.ReturnStockAmount("Milk")}";
            ChocolateStockTextBox.Text = $"{stockObj.ReturnStockAmount("Chocolate")}";
            CoffeeStockTextBox.Text = $"{stockObj.ReturnStockAmount("Coffee")}";
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateStock();


        }

        private async void RestockButton_Click(object sender, EventArgs e)
        {
            //Restock function from restock class called so 10 added to all item stock
            Restock restockObj = new Restock();
            restockObj.RestockAll();

            //Stock boxes populated again with updated stock
            PopulateStock();

            //Restock button temp disabled (3sec) to simulate real restocking
            RestockButton.Enabled = false;
            LogTextBox.Text = "> Restocking Items..." + Environment.NewLine;
            await Task.Delay(3000);

            LogTextBox.AppendText("> All items restocked!" + Environment.NewLine);
            RestockButton.Enabled = true;
        }

        private void Amount_TextChanged(object sender, EventArgs e)
        {
            int balance;
            if (int.TryParse(AmountTextBox.Text, out balance) && balance > 0 && (balance % 10 == 0) || (balance % 5 == 0))
            { 
                LogTextBox.Text = ($"{balance}"); 
            
            }
        }

        private void Amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Process the input
                string input = AmountTextBox.Text;
                MessageBox.Show("You entered: " + input);

                // Optionally, clear the text box
                AmountTextBox.Clear();
            }
        }

    }
}
