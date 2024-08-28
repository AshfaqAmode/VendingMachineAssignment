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
//using VendingMachineAssignment.Presentation_Layer;


namespace VendingMachineAssignment
{
    public partial class Form1 : Form
    {
        private int balance;

        string[,] drinksAndIngredients = new string[,]
        {
            { "Tea", "Milk", "Tea", "" }, // Last column left empty for variable length
            { "Cappuccino", "Milk", "Coffee", "" },
            { "Mochaccino", "Milk", "Coffee", "Chocolate" },
            { "Hot Chocolate", "Milk", "Chocolate", "" },
            { "Milk", "Milk", "", "" }
        };

        //enters loaded data values from the db into stock boxes
        public void PopulateStock()
        {
            var stockObj = new DisplayStock();

            TeaStockTextBox.Text = $"{stockObj.ReturnStockAmount("Tea")}";
            SugarStockTextBox.Text = $"{stockObj.ReturnStockAmount("Sugar")}";
            MilkStockTextBox.Text = $"{stockObj.ReturnStockAmount("Milk")}";
            ChocolateStockTextBox.Text = $"{stockObj.ReturnStockAmount("Chocolate")}";
            CoffeeStockTextBox.Text = $"{stockObj.ReturnStockAmount("Coffee")}";
            AmountTextBox.Text = $"{balance}";
        }


        //removes a sugar from the stock
        private async void SugarChoice()
        {
            if (!(WithoutSugarCheckBox.Checked))
            {
                DrinkButtons a = new DrinkButtons();
                LogTextBox.AppendText($"> Adding Sugar..." + Environment.NewLine);
                a.TakeDrinkIngredients("Sugar");
                PopulateStock();
                await Task.Delay(2000);
            }
        }

        private async void DrinkSelected(string currentDrink)
        {
            ButtonControl.DisableAllControls(this);
            DrinkButtons a = new DrinkButtons();

            if (a.PurchaseDrink($"{currentDrink}", ref balance))
            {
                LogTextBox.AppendText(Environment.NewLine + $"> {currentDrink} selected" + Environment.NewLine);
                await Task.Delay(500);

                for (int i = 0; i < drinksAndIngredients.GetLength(0); i++)
                {
                    string drink = drinksAndIngredients[i, 0];
                    for (int j = 1; j < drinksAndIngredients.GetLength(1); j++)
                    {
                        if (drink == currentDrink)
                        {
                            if (!(drinksAndIngredients[i, j] == ""))
                            {
                                LogTextBox.AppendText($"> Adding {drinksAndIngredients[i, j]}..." + Environment.NewLine);
                                a.TakeDrinkIngredients($"{drinksAndIngredients[i, j]}");
                                PopulateStock();
                                await Task.Delay(2000);
                            }
                        }
                    }
                }
                SugarChoice();

                LogTextBox.AppendText($"> Drink Served!" + Environment.NewLine);
                LogTextBox.AppendText(Environment.NewLine + $"> Remaining Balance: {balance}" + Environment.NewLine);
                AmountTextBox.Text = $"{balance}";
                await Task.Delay(1000);
                ButtonControl.EnableAllControls(this);
            }
            else
            {
                LogTextBox.AppendText($"> Insufficient balance. Add more money or make another choice{Environment.NewLine}");
                AmountTextBox.Text = $"{balance}";
                await Task.Delay(1000);
                ButtonControl.EnableAllControls(this);
            }

        }



        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateStock();
            var sam = new DisplayStock();
            sam.CheckStockAmount();
        }

        private async void RestockButton_Click(object sender, EventArgs e)
        {
            //Restock function from restock class called so 10 added to all item stock
            Stock restockObj = new Stock();
            restockObj.RestockAll();

            //Stock boxes populated again with updated stock
            PopulateStock();

            //all buttons disabled for 3 sec while restocking
            ButtonControl.DisableAllControls(this);
            LogTextBox.Text = "> Restocking Items..." + Environment.NewLine;
            await Task.Delay(3000);

            LogTextBox.AppendText("> All items restocked!" + Environment.NewLine);
            ButtonControl.EnableAllControls(this);
        }

        private async void Amount_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                // Process the input
                string input = AmountTextBox.Text;

                if (!(int.TryParse(AmountTextBox.Text, out balance) && balance > 0 && balance < 1000))
                {
                    MessageBox.Show("We only accept Rs 1, 5, 10, 20 coins and Rs 25, 50, 100 notes\n\t\tMaximum Rs 1000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AmountTextBox.Clear();
                }
                else
                {
                    AmountTextBox.Clear();
                    ButtonControl.DisableAllControls(this);
                    LogTextBox.Text = "> Reading Amount..." + Environment.NewLine;
                    await Task.Delay(2000);

                    LogTextBox.AppendText($"> Balance: {balance}" + Environment.NewLine);
                    ButtonControl.EnableAllControls(this);
                    PopulateStock();
                }

            }
        }

        private void TeaButton_Click(object sender, EventArgs e)
        {
            DrinkSelected("Tea");
        }

        private void CappucinoButton_Click(object sender, EventArgs e)
        {
            DrinkSelected("Cappuccino");
        }

        private void MochaccinoButton_Click(object sender, EventArgs e)
        {
            DrinkSelected("Mochaccino");
        }

        private void HotChocolateButton_Click(object sender, EventArgs e)
        {
            DrinkSelected("Hot Chocolate");
        }

        private void MilkButton_Click(object sender, EventArgs e)
        {
            DrinkSelected("Milk");
        }
    }
}
