namespace VendingMachineAssignment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.VendingMachineLabel = new System.Windows.Forms.Label();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.LogLabel = new System.Windows.Forms.Label();
            this.WithoutSugarCheckBox = new System.Windows.Forms.CheckBox();
            this.TeaButton = new System.Windows.Forms.Button();
            this.CappucinoButton = new System.Windows.Forms.Button();
            this.MochaccinoButton = new System.Windows.Forms.Button();
            this.HotChocolateButton = new System.Windows.Forms.Button();
            this.MilkButton = new System.Windows.Forms.Button();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.StockAvailableLabel = new System.Windows.Forms.Label();
            this.TeaStockLabel = new System.Windows.Forms.Label();
            this.CappucinoStockLabel = new System.Windows.Forms.Label();
            this.CoffeeStockLabel = new System.Windows.Forms.Label();
            this.MilkStockLabel = new System.Windows.Forms.Label();
            this.HotChocolateStockLabel = new System.Windows.Forms.Label();
            this.ChocolateStockLabel = new System.Windows.Forms.Label();
            this.SugarStockLabel = new System.Windows.Forms.Label();
            this.TeaStockTextBox = new System.Windows.Forms.TextBox();
            this.SugarStockTextBox = new System.Windows.Forms.TextBox();
            this.CoffeeStockTextBox = new System.Windows.Forms.TextBox();
            this.ChocolateStockTextBox = new System.Windows.Forms.TextBox();
            this.MilkStockTextBox = new System.Windows.Forms.TextBox();
            this.RestockButton = new System.Windows.Forms.Button();
            this.vendingMachineDataSet = new VendingMachineAssignment.VendingMachineDataSet();
            this.vendingMachineDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.drinksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.drinksTableAdapter = new VendingMachineAssignment.VendingMachineDataSetTableAdapters.DrinksTableAdapter();
            this.drinksBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ingredientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ingredientsTableAdapter = new VendingMachineAssignment.VendingMachineDataSetTableAdapters.IngredientsTableAdapter();
            this.vendingMachineDataSet1 = new VendingMachineAssignment.VendingMachineDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.vendingMachineDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendingMachineDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drinksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drinksBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendingMachineDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // VendingMachineLabel
            // 
            this.VendingMachineLabel.AutoSize = true;
            this.VendingMachineLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VendingMachineLabel.Location = new System.Drawing.Point(200, 32);
            this.VendingMachineLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VendingMachineLabel.Name = "VendingMachineLabel";
            this.VendingMachineLabel.Size = new System.Drawing.Size(211, 28);
            this.VendingMachineLabel.TabIndex = 0;
            this.VendingMachineLabel.Text = "Vending Machine";
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Location = new System.Drawing.Point(30, 95);
            this.AmountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(65, 20);
            this.AmountLabel.TabIndex = 1;
            this.AmountLabel.Text = "Amount";
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.Location = new System.Drawing.Point(106, 91);
            this.AmountTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.Size = new System.Drawing.Size(112, 26);
            this.AmountTextBox.TabIndex = 2;
            this.AmountTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Amount_KeyDown);
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(57, 205);
            this.LogLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(36, 20);
            this.LogLabel.TabIndex = 3;
            this.LogLabel.Text = "Log";
            // 
            // WithoutSugarCheckBox
            // 
            this.WithoutSugarCheckBox.AutoSize = true;
            this.WithoutSugarCheckBox.Location = new System.Drawing.Point(438, 142);
            this.WithoutSugarCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WithoutSugarCheckBox.Name = "WithoutSugarCheckBox";
            this.WithoutSugarCheckBox.Size = new System.Drawing.Size(137, 24);
            this.WithoutSugarCheckBox.TabIndex = 4;
            this.WithoutSugarCheckBox.Text = "Without Sugar";
            this.WithoutSugarCheckBox.UseVisualStyleBackColor = true;
            // 
            // TeaButton
            // 
            this.TeaButton.Location = new System.Drawing.Point(440, 229);
            this.TeaButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TeaButton.Name = "TeaButton";
            this.TeaButton.Size = new System.Drawing.Size(147, 35);
            this.TeaButton.TabIndex = 5;
            this.TeaButton.Text = "Tea";
            this.TeaButton.UseVisualStyleBackColor = true;
            this.TeaButton.Click += new System.EventHandler(this.TeaButton_Click);
            // 
            // CappucinoButton
            // 
            this.CappucinoButton.Location = new System.Drawing.Point(440, 274);
            this.CappucinoButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CappucinoButton.Name = "CappucinoButton";
            this.CappucinoButton.Size = new System.Drawing.Size(147, 35);
            this.CappucinoButton.TabIndex = 6;
            this.CappucinoButton.Text = "Cappucino";
            this.CappucinoButton.UseVisualStyleBackColor = true;
            this.CappucinoButton.Click += new System.EventHandler(this.CappucinoButton_Click);
            // 
            // MochaccinoButton
            // 
            this.MochaccinoButton.Location = new System.Drawing.Point(440, 318);
            this.MochaccinoButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MochaccinoButton.Name = "MochaccinoButton";
            this.MochaccinoButton.Size = new System.Drawing.Size(147, 35);
            this.MochaccinoButton.TabIndex = 7;
            this.MochaccinoButton.Text = "Mochaccino";
            this.MochaccinoButton.UseVisualStyleBackColor = true;
            this.MochaccinoButton.Click += new System.EventHandler(this.MochaccinoButton_Click);
            // 
            // HotChocolateButton
            // 
            this.HotChocolateButton.Location = new System.Drawing.Point(440, 363);
            this.HotChocolateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HotChocolateButton.Name = "HotChocolateButton";
            this.HotChocolateButton.Size = new System.Drawing.Size(147, 35);
            this.HotChocolateButton.TabIndex = 8;
            this.HotChocolateButton.Text = "Hot Chocolate";
            this.HotChocolateButton.UseVisualStyleBackColor = true;
            this.HotChocolateButton.Click += new System.EventHandler(this.HotChocolateButton_Click);
            // 
            // MilkButton
            // 
            this.MilkButton.Location = new System.Drawing.Point(440, 408);
            this.MilkButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MilkButton.Name = "MilkButton";
            this.MilkButton.Size = new System.Drawing.Size(147, 35);
            this.MilkButton.TabIndex = 9;
            this.MilkButton.Text = "Milk";
            this.MilkButton.UseVisualStyleBackColor = true;
            this.MilkButton.Click += new System.EventHandler(this.MilkButton_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.AcceptsReturn = true;
            this.LogTextBox.Location = new System.Drawing.Point(58, 229);
            this.LogTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(314, 212);
            this.LogTextBox.TabIndex = 10;
            // 
            // StockAvailableLabel
            // 
            this.StockAvailableLabel.AutoSize = true;
            this.StockAvailableLabel.Location = new System.Drawing.Point(30, 506);
            this.StockAvailableLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StockAvailableLabel.Name = "StockAvailableLabel";
            this.StockAvailableLabel.Size = new System.Drawing.Size(117, 20);
            this.StockAvailableLabel.TabIndex = 12;
            this.StockAvailableLabel.Text = "Stock Available";
            // 
            // TeaStockLabel
            // 
            this.TeaStockLabel.AutoSize = true;
            this.TeaStockLabel.Location = new System.Drawing.Point(30, 549);
            this.TeaStockLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TeaStockLabel.Name = "TeaStockLabel";
            this.TeaStockLabel.Size = new System.Drawing.Size(36, 20);
            this.TeaStockLabel.TabIndex = 13;
            this.TeaStockLabel.Text = "Tea";
            // 
            // CappucinoStockLabel
            // 
            this.CappucinoStockLabel.AutoSize = true;
            this.CappucinoStockLabel.Location = new System.Drawing.Point(249, 565);
            this.CappucinoStockLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CappucinoStockLabel.Name = "CappucinoStockLabel";
            this.CappucinoStockLabel.Size = new System.Drawing.Size(0, 20);
            this.CappucinoStockLabel.TabIndex = 14;
            // 
            // CoffeeStockLabel
            // 
            this.CoffeeStockLabel.AutoSize = true;
            this.CoffeeStockLabel.Location = new System.Drawing.Point(314, 549);
            this.CoffeeStockLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CoffeeStockLabel.Name = "CoffeeStockLabel";
            this.CoffeeStockLabel.Size = new System.Drawing.Size(57, 20);
            this.CoffeeStockLabel.TabIndex = 15;
            this.CoffeeStockLabel.Text = "Coffee";
            // 
            // MilkStockLabel
            // 
            this.MilkStockLabel.AutoSize = true;
            this.MilkStockLabel.Location = new System.Drawing.Point(126, 549);
            this.MilkStockLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MilkStockLabel.Name = "MilkStockLabel";
            this.MilkStockLabel.Size = new System.Drawing.Size(36, 20);
            this.MilkStockLabel.TabIndex = 16;
            this.MilkStockLabel.Text = "Milk";
            // 
            // HotChocolateStockLabel
            // 
            this.HotChocolateStockLabel.AutoSize = true;
            this.HotChocolateStockLabel.Location = new System.Drawing.Point(370, 549);
            this.HotChocolateStockLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HotChocolateStockLabel.Name = "HotChocolateStockLabel";
            this.HotChocolateStockLabel.Size = new System.Drawing.Size(0, 20);
            this.HotChocolateStockLabel.TabIndex = 17;
            // 
            // ChocolateStockLabel
            // 
            this.ChocolateStockLabel.AutoSize = true;
            this.ChocolateStockLabel.Location = new System.Drawing.Point(200, 549);
            this.ChocolateStockLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ChocolateStockLabel.Name = "ChocolateStockLabel";
            this.ChocolateStockLabel.Size = new System.Drawing.Size(81, 20);
            this.ChocolateStockLabel.TabIndex = 17;
            this.ChocolateStockLabel.Text = "Chocolate";
            // 
            // SugarStockLabel
            // 
            this.SugarStockLabel.AutoSize = true;
            this.SugarStockLabel.Location = new System.Drawing.Point(412, 549);
            this.SugarStockLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SugarStockLabel.Name = "SugarStockLabel";
            this.SugarStockLabel.Size = new System.Drawing.Size(52, 20);
            this.SugarStockLabel.TabIndex = 14;
            this.SugarStockLabel.Text = "Sugar";
            // 
            // TeaStockTextBox
            // 
            this.TeaStockTextBox.Location = new System.Drawing.Point(34, 591);
            this.TeaStockTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TeaStockTextBox.Name = "TeaStockTextBox";
            this.TeaStockTextBox.ReadOnly = true;
            this.TeaStockTextBox.Size = new System.Drawing.Size(43, 26);
            this.TeaStockTextBox.TabIndex = 18;
            // 
            // SugarStockTextBox
            // 
            this.SugarStockTextBox.Location = new System.Drawing.Point(420, 589);
            this.SugarStockTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SugarStockTextBox.Name = "SugarStockTextBox";
            this.SugarStockTextBox.ReadOnly = true;
            this.SugarStockTextBox.Size = new System.Drawing.Size(43, 26);
            this.SugarStockTextBox.TabIndex = 19;
            // 
            // CoffeeStockTextBox
            // 
            this.CoffeeStockTextBox.Location = new System.Drawing.Point(318, 589);
            this.CoffeeStockTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CoffeeStockTextBox.Name = "CoffeeStockTextBox";
            this.CoffeeStockTextBox.ReadOnly = true;
            this.CoffeeStockTextBox.Size = new System.Drawing.Size(43, 26);
            this.CoffeeStockTextBox.TabIndex = 20;
            // 
            // ChocolateStockTextBox
            // 
            this.ChocolateStockTextBox.Location = new System.Drawing.Point(219, 589);
            this.ChocolateStockTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChocolateStockTextBox.Name = "ChocolateStockTextBox";
            this.ChocolateStockTextBox.ReadOnly = true;
            this.ChocolateStockTextBox.Size = new System.Drawing.Size(43, 26);
            this.ChocolateStockTextBox.TabIndex = 21;
            // 
            // MilkStockTextBox
            // 
            this.MilkStockTextBox.Location = new System.Drawing.Point(123, 589);
            this.MilkStockTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MilkStockTextBox.Name = "MilkStockTextBox";
            this.MilkStockTextBox.ReadOnly = true;
            this.MilkStockTextBox.Size = new System.Drawing.Size(43, 26);
            this.MilkStockTextBox.TabIndex = 22;
            // 
            // RestockButton
            // 
            this.RestockButton.Location = new System.Drawing.Point(489, 551);
            this.RestockButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RestockButton.Name = "RestockButton";
            this.RestockButton.Size = new System.Drawing.Size(122, 71);
            this.RestockButton.TabIndex = 23;
            this.RestockButton.Text = "Restock";
            this.RestockButton.UseVisualStyleBackColor = true;
            this.RestockButton.Click += new System.EventHandler(this.RestockButton_Click);
            // 
            // vendingMachineDataSet
            // 
            this.vendingMachineDataSet.DataSetName = "VendingMachineDataSet";
            this.vendingMachineDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vendingMachineDataSetBindingSource
            // 
            this.vendingMachineDataSetBindingSource.DataSource = this.vendingMachineDataSet;
            this.vendingMachineDataSetBindingSource.Position = 0;
            // 
            // drinksBindingSource
            // 
            this.drinksBindingSource.DataMember = "Drinks";
            this.drinksBindingSource.DataSource = this.vendingMachineDataSetBindingSource;
            // 
            // drinksTableAdapter
            // 
            this.drinksTableAdapter.ClearBeforeFill = true;
            // 
            // drinksBindingSource1
            // 
            this.drinksBindingSource1.DataMember = "Drinks";
            this.drinksBindingSource1.DataSource = this.vendingMachineDataSetBindingSource;
            // 
            // ingredientsBindingSource
            // 
            this.ingredientsBindingSource.DataMember = "Ingredients";
            this.ingredientsBindingSource.DataSource = this.vendingMachineDataSetBindingSource;
            // 
            // ingredientsTableAdapter
            // 
            this.ingredientsTableAdapter.ClearBeforeFill = true;
            // 
            // vendingMachineDataSet1
            // 
            this.vendingMachineDataSet1.DataSetName = "VendingMachineDataSet";
            this.vendingMachineDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(633, 642);
            this.Controls.Add(this.RestockButton);
            this.Controls.Add(this.MilkStockTextBox);
            this.Controls.Add(this.ChocolateStockTextBox);
            this.Controls.Add(this.CoffeeStockTextBox);
            this.Controls.Add(this.SugarStockTextBox);
            this.Controls.Add(this.TeaStockTextBox);
            this.Controls.Add(this.ChocolateStockLabel);
            this.Controls.Add(this.HotChocolateStockLabel);
            this.Controls.Add(this.MilkStockLabel);
            this.Controls.Add(this.CoffeeStockLabel);
            this.Controls.Add(this.SugarStockLabel);
            this.Controls.Add(this.CappucinoStockLabel);
            this.Controls.Add(this.TeaStockLabel);
            this.Controls.Add(this.StockAvailableLabel);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.MilkButton);
            this.Controls.Add(this.HotChocolateButton);
            this.Controls.Add(this.MochaccinoButton);
            this.Controls.Add(this.CappucinoButton);
            this.Controls.Add(this.TeaButton);
            this.Controls.Add(this.WithoutSugarCheckBox);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.AmountTextBox);
            this.Controls.Add(this.AmountLabel);
            this.Controls.Add(this.VendingMachineLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vendingMachineDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendingMachineDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drinksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drinksBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendingMachineDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VendingMachineLabel;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.TextBox AmountTextBox;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.CheckBox WithoutSugarCheckBox;
        private System.Windows.Forms.Button TeaButton;
        private System.Windows.Forms.Button CappucinoButton;
        private System.Windows.Forms.Button MochaccinoButton;
        private System.Windows.Forms.Button HotChocolateButton;
        private System.Windows.Forms.Button MilkButton;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Label StockAvailableLabel;
        private System.Windows.Forms.Label TeaStockLabel;
        private System.Windows.Forms.Label CappucinoStockLabel;
        private System.Windows.Forms.Label CoffeeStockLabel;
        private System.Windows.Forms.Label MilkStockLabel;
        private System.Windows.Forms.Label HotChocolateStockLabel;
        private System.Windows.Forms.Label ChocolateStockLabel;
        private System.Windows.Forms.Label SugarStockLabel;
        private System.Windows.Forms.TextBox TeaStockTextBox;
        private System.Windows.Forms.TextBox SugarStockTextBox;
        private System.Windows.Forms.TextBox CoffeeStockTextBox;
        private System.Windows.Forms.TextBox ChocolateStockTextBox;
        private System.Windows.Forms.TextBox MilkStockTextBox;
        private System.Windows.Forms.Button RestockButton;
        private System.Windows.Forms.BindingSource vendingMachineDataSetBindingSource;
        private VendingMachineDataSet vendingMachineDataSet;
        private System.Windows.Forms.BindingSource drinksBindingSource;
        private VendingMachineDataSetTableAdapters.DrinksTableAdapter drinksTableAdapter;
        private System.Windows.Forms.BindingSource drinksBindingSource1;
        private System.Windows.Forms.BindingSource ingredientsBindingSource;
        private VendingMachineDataSetTableAdapters.IngredientsTableAdapter ingredientsTableAdapter;
        private VendingMachineDataSet vendingMachineDataSet1;
    }
}

