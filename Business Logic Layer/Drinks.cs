using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment.Business_Logic_Layer
{
    internal class Drinks
    {
        private int _drinkId;
        private string _drinkName;
        private int _drinkPrice;

        public Drinks(int drinkId, string drinkName, int drinkPrice)
        {
            DrinkId = drinkId;
            DrinkName = drinkName;
            DrinkStock = drinkPrice;
        }

        public int DrinkId { get => _drinkId; set => _drinkId = value; }
        public string DrinkName { get => _drinkName; set => _drinkName = value; }
        public int DrinkStock { get => _drinkPrice; set => _drinkPrice = value; }
    }
}
