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
//using VendingMachineAssignment.Constant;
using VendingMachineAssignment.Business_Logic_Layer;
//using VendingMachineAssignment.Presentation_Layer;


namespace VendingMachineAssignment
{
    public partial class Form1 : Form
    {
        private int balance;

        List<Ingredients> ingredientsList = new List<Ingredients>();
        List<Drinks> drinksList = new List<Drinks>();


        //enters loaded data values from the ingredient list into stock boxes
        public void PopulateStock(List<Ingredients> ingredientsList)
        {
            AmountTextBox.Text = $"{balance}";
            TeaStockTextBox.Text = $"{ingredientsList.Where(i => i.IngredientName == "Tea").Select(i => i.IngredientStock).First()}";
            SugarStockTextBox.Text = $"{ingredientsList.Where(i => i.IngredientName == "Sugar").Select(i => i.IngredientStock).First()}";
            MilkStockTextBox.Text = $"{ingredientsList.Where(i => i.IngredientName == "Milk").Select(i => i.IngredientStock).First()}";
            ChocolateStockTextBox.Text = $"{ingredientsList.Where(i => i.IngredientName == "Chocolate").Select(i => i.IngredientStock).First()}";
            CoffeeStockTextBox.Text = $"{ingredientsList.Where(i => i.IngredientName == "Coffee").Select(i => i.IngredientStock).First()}";
        }


        //removes a sugar from the stock
        private async void SugarChoice()
        {
            if (!(WithoutSugarCheckBox.Checked))
            {
                DrinkOperations a = new DrinkOperations();
                LogTextBox.AppendText($"> Adding Sugar..." + Environment.NewLine);
                //await Task.Delay(2000);
                var sugar = ingredientsList.FirstOrDefault(s => s.IngredientId == (int)Constant.Ingredient.Sugar);
                sugar.IngredientStock -= 1;
                sugar.Changed = true;
                PopulateStock(ingredientsList);
            }
        }

        public async void AssembleDrink(int drinkId, List<Ingredients> ingredientList, List<Drinks> drinkList)
        {
            IDbOperations conn = new DbOperations();
            var drink = drinkList.FirstOrDefault(d => d.DrinkId == drinkId);
            var ingredientsNeeded = drink.IngredientIds;

            if (drink != null)
            {
                foreach (int ingredientId in ingredientsNeeded)
                {

                    var ingredient = ingredientList.FirstOrDefault(i => i.IngredientId == ingredientId);
                    if (ingredient != null)
                    {
                        LogTextBox.AppendText($"> Adding {ingredient.IngredientName}..." + Environment.NewLine);
                        LogTextBox.Refresh();
                        //await Task.Delay(2000);

                        ingredient.IngredientStock -= 1;
                        ingredient.Changed = true;
                        PopulateStock(ingredientsList);

                    }
                }
            }

            conn.UpdateIngredientStockDB(ingredientList);
            PopulateStock(ingredientsList);
        }


        private async void DrinkSelected(int drinkId)
        {
            ButtonControl.DisableAllControls(this);
            DrinkOperations a = new DrinkOperations();

            if(a.HasStock(drinkId, drinksList, ingredientsList))
            {
                if (a.HasBalance(balance, drinkId, drinksList))
                {

                    balance = a.PayDrink(drinkId, balance, drinksList);


                    string drinkName = drinksList.Where(drink => drink.DrinkId == drinkId).Select(drink => drink.DrinkName).FirstOrDefault();
                    
                    LogTextBox.AppendText(Environment.NewLine + $"> {drinkName} selected" + Environment.NewLine);
                    //await Task.Delay(500);
                    
                    
                    AssembleDrink(drinkId, ingredientsList, drinksList);
                    SugarChoice();
                    
                    LogTextBox.AppendText($"> Drink Served! {Environment.NewLine}");
                    ButtonControl.EnableAllControls(this);
                }
                else
                {
                    LogTextBox.AppendText($"> Insufficient balance. Add more money or make another choice{Environment.NewLine}");
                    AmountTextBox.Text = $"{balance}";
                    //await Task.Delay(1000);
                    ButtonControl.EnableAllControls(this);
                }
            }
            else
            {
                LogTextBox.AppendText($"> Insufficient stock for chosen drink. Contact admin to restock or make another choice{Environment.NewLine}");
                AmountTextBox.Text = $"{balance}";
                //await Task.Delay(1000);
                ButtonControl.EnableAllControls(this);
            }

        }

        private void CheckStock(List<Ingredients> ingredientsList)
        {

            var sam = new StockOperations();

            if (sam.CheckAllStockAmount(ingredientsList) == true)
            {
                LogTextBox.Text = $"> URGENT... Please restock!";
                ButtonControl.DisableAllControls(this);
                RestockButton.Enabled = true;
            };
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            IDbOperations conn = new DbOperations();

            ingredientsList = conn.GetIngredientsList(Constant.selectIngredientsQuery);
            drinksList = conn.GetFullDrinksList(Constant.selectLeftJoinDrinksIngredientsQuery);

            //populate  stock boxes on open
            PopulateStock(ingredientsList);

            //check stock on load
            CheckStock(ingredientsList );
            
        }

        private async void RestockButton_Click(object sender, EventArgs e)
        {
            //Restock function from restock class called so 10 added to all item stock
            IStockOperations restockObj = new StockOperations();

            //all buttons disabled for 3 sec while restocking
            ButtonControl.DisableAllControls(this);
            LogTextBox.Text = "> Restocking Items..." + Environment.NewLine;
            //await Task.Delay(3000);

            restockObj.RestockAll(ingredientsList);

            //Stock boxes populated again with updated stock
            PopulateStock(ingredientsList);

            LogTextBox.AppendText("> All items restocked!" + Environment.NewLine);
            ButtonControl.EnableAllControls(this);
            CheckStock(ingredientsList);
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
                    //await Task.Delay(2000);

                    LogTextBox.AppendText($"> Balance: {balance}" + Environment.NewLine);
                    ButtonControl.EnableAllControls(this);
                    PopulateStock(ingredientsList);
                }

            }
        }

        private void TeaButton_Click(object sender, EventArgs e)
        {
            DrinkSelected((int)Constant.Drink.Tea);
        }

        private void CappucinoButton_Click(object sender, EventArgs e)
        {
            DrinkSelected((int)Constant.Drink.Cappuccino);
        }

        private void MochaccinoButton_Click(object sender, EventArgs e)
        {
            DrinkSelected((int)Constant.Drink.Mochaccino);
        }

        private void HotChocolateButton_Click(object sender, EventArgs e)
        {
            DrinkSelected((int)Constant.Drink.HotChocolate);
        }

        private void MilkButton_Click(object sender, EventArgs e)
        {
            DrinkSelected((int)Constant.Drink.Milk);
        }
    }
}
