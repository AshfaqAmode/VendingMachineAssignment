using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineAssignment.Business_Logic_Layer;

namespace VendingMachineAssignment
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            IDbConnection conn = new DbAccess();
            List<Drinks> a = conn.GetDrinksList("SELECT * FROM Drinks");
            foreach (var drink in a)
            {
                MessageBox.Show($"{drink.DrinkName}, {drink.DrinkId}, {drink.DrinkPrice}");
            }
        }
    }
}
