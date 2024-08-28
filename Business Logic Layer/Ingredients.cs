using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment.Business_Logic_Layer
{
    public class Ingredients
    {
        private int _ingredientId;
        private string _ingredientName;
        private int _ingredientStock;

        public Ingredients(int ingredientId, string ingredientName, int ingredientStock)
        {
            IngredientId = ingredientId;
            IngredientName = ingredientName;
            IngredientStock = ingredientStock;
        }

        public int IngredientId { get => _ingredientId; set => _ingredientId = value; }
        public string IngredientName { get => _ingredientName; set => _ingredientName = value; }
        public int IngredientStock { get => _ingredientStock; set => _ingredientStock = value; }

    }
}
