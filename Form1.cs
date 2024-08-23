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

            //all buttons disabled for 3 sec while restocking
            DisableAllControls(this);
            LogTextBox.Text = "> Restocking Items..." + Environment.NewLine;
            await Task.Delay(3000);

            LogTextBox.AppendText("> All items restocked!" + Environment.NewLine);
            EnableAllControls(this);
        }


        //functions to disable all controls while drink is being made or restocking 
        private void DisableAllControls(Form form)
        {
            foreach (Control control in form.Controls)
            {
                control.Enabled = false;
            }
        }
        private void EnableAllControls(Form form)
        {
            foreach (Control control in form.Controls)
            {
                control.Enabled = true;
            }
        }


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
            DisableAllControls(this);
            DrinkButtons a = new DrinkButtons();
            
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
            EnableAllControls(this);
            
        }

        private async void CappucinoButton_Click(object sender, EventArgs e)
        {
            DisableAllControls(this);
            DrinkButtons a = new DrinkButtons();

            LogTextBox.Text = "> Cappucino selected" + Environment.NewLine;
            await Task.Delay(500);


            LogTextBox.AppendText($"> Adding Milk..." + Environment.NewLine);
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Milk'");
            PopulateStock();
            await Task.Delay(2000);


            LogTextBox.AppendText($"> Adding Coffee..." + Environment.NewLine);
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Coffee'");
            PopulateStock();
            await Task.Delay(2000);

            LogTextBox.AppendText($"> Drink Served!" + Environment.NewLine);
            EnableAllControls(this);
        }

        private async void MochaccinoButton_Click(object sender, EventArgs e)
        {
            DisableAllControls(this);
            DrinkButtons a = new DrinkButtons();

            LogTextBox.Text = "> Mochaccino selected" + Environment.NewLine;
            await Task.Delay(500);


            LogTextBox.AppendText($"> Adding Milk..." + Environment.NewLine);
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Milk'");
            PopulateStock();
            await Task.Delay(2000);


            LogTextBox.AppendText($"> Adding Coffee..." + Environment.NewLine);
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Coffee'");
            PopulateStock();
            await Task.Delay(2000);

            LogTextBox.AppendText($"> Adding Chocolate..." + Environment.NewLine);
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Chocolate'");
            PopulateStock();
            await Task.Delay(2000);

            LogTextBox.AppendText($"> Drink Served!" + Environment.NewLine);
            EnableAllControls(this);
        }

        private async void HotChocolateButton_Click(object sender, EventArgs e)
        {
            DisableAllControls(this);
            DrinkButtons a = new DrinkButtons();

            LogTextBox.Text = "> Hot Chocolate selected" + Environment.NewLine;
            await Task.Delay(500);

            LogTextBox.AppendText($"> Adding Milk..." + Environment.NewLine);
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Milk'");
            PopulateStock();
            await Task.Delay(2000);

            LogTextBox.AppendText($"> Adding Chocolate..." + Environment.NewLine);
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Chocolate'");
            PopulateStock();
            await Task.Delay(2000);

            LogTextBox.AppendText($"> Drink Served!" + Environment.NewLine);
            EnableAllControls(this);

        }

        private async void MilkButton_Click(object sender, EventArgs e)
        {
            DisableAllControls(this);
            DrinkButtons a = new DrinkButtons();

            LogTextBox.Text = "> Milk selected" + Environment.NewLine;
            await Task.Delay(500);

            LogTextBox.AppendText($"> Adding Milk..." + Environment.NewLine);
            a.TakeDrink("IngredientStock = IngredientStock - 1 WHERE IngredientName = 'Milk'");
            PopulateStock();
            await Task.Delay(2000);

            LogTextBox.AppendText($"> Drink Served!" + Environment.NewLine);
            EnableAllControls(this);
        }
    }
}
