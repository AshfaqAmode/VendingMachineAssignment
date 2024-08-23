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

        //private async void TempDisableAllButtons()
        //{
        //    foreach (Control control in this.Controls)
        //    {
        //        if (control is Button button)
        //        {
        //            button.Enabled = false;
        //            await Task.Delay(2000);
        //            button.Enabled = true;
        //        }
        //    }
        //}


        private async void Amount_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                // Process the input
                string input = AmountTextBox.Text;

                int balance;
                if (!(int.TryParse(AmountTextBox.Text, out balance) && balance > 0 && balance < 1000))
                {
                    MessageBox.Show("We only accept Rs 1, 5, 10, 20 coins and Rs 25, 50, 100 notes\n\t\tMaximum Rs 1000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AmountTextBox.Clear();
                }
                else
                {
                    AmountTextBox.Clear();
                    AmountTextBox.Enabled = false;
                    LogTextBox.Text = "> Reading Amount..." + Environment.NewLine;
                    await Task.Delay(2000);

                    LogTextBox.AppendText($"> Balance: {balance}" + Environment.NewLine);
                    AmountTextBox.Enabled = true;
                }
                
            }
        }

        private async void TeaButton_Click(object sender, EventArgs e)
        {
            
            DrinkButtons a = new DrinkButtons();
            
            TeaButton.Enabled = false;
            LogTextBox.Text = "> Tea selected" + Environment.NewLine;
            await Task.Delay(500);

            LogTextBox.AppendText($"> Adding Tea..." + Environment.NewLine);
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Tea'");
            PopulateStock();
            await Task.Delay(2000);

            LogTextBox.AppendText($"> Adding Milk..." + Environment.NewLine);
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Milk'");
            PopulateStock();
            await Task.Delay(2000);

            LogTextBox.AppendText($"> Drink Served!" + Environment.NewLine);
            TeaButton.Enabled = true;
        }

        private void CappucinoButton_Click(object sender, EventArgs e)
        {
            DrinkButtons a = new DrinkButtons();
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Milk'");
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Coffee'");
            PopulateStock();
        }

        private void MochaccinoButton_Click(object sender, EventArgs e)
        {
            DrinkButtons a = new DrinkButtons();
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Milk'");
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Coffee'");
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Chocolate'");
            PopulateStock();
        }

        private void HotChocolateButton_Click(object sender, EventArgs e)
        {
            DrinkButtons a = new DrinkButtons();
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Milk'");
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Chocolate'");
            PopulateStock();
        }

        private void MilkButton_Click(object sender, EventArgs e)
        {
            DrinkButtons a = new DrinkButtons();
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Milk'");
            PopulateStock();
        }
    }
}
