using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment.Business_Logic_Layer
{
    public class DrinksIngredients
    {
        private int _drinkId;
        private int _ingredientId;

        public DrinksIngredients(int drinkId, int ingredientId)
        {
            DrinkId = drinkId;
            IngredientId = ingredientId;
        }

        public int DrinkId { get => _drinkId; set => _drinkId = value; }
        public int IngredientId { get => _ingredientId; set => _ingredientId = value; }

    }
}
