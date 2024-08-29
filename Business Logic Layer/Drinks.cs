﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment.Business_Logic_Layer
{
    public class Drinks
    {
        private int _drinkId;
        private string _drinkName;
        private int _drinkPrice;
        private List<Ingredients> _ingredientsList = new List<Ingredients> { };


        //public Drinks(int drinkId, string drinkName, int drinkPrice)
        //{
        //    DrinkId = drinkId;
        //    DrinkName = drinkName;
        //    DrinkPrice = drinkPrice;
        //}

        public Drinks(int drinkId, string drinkName, int drinkPrice)
        {
            DrinkId = drinkId;
            DrinkName = drinkName;
            DrinkPrice = drinkPrice;
        }

        public int DrinkId { get => _drinkId; set => _drinkId = value; }
        public string DrinkName { get => _drinkName; set => _drinkName = value; }
        public int DrinkPrice { get => _drinkPrice; set => _drinkPrice = value; }
        public List<Ingredients> IngredientsList { get => _ingredientsList; set => _ingredientsList = value; }
    }
}
