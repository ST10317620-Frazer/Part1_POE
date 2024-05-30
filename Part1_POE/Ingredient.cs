using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_POE
{
    internal class Ingredient
    {
        //These are basic getters and setters.
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
        private double originalQuantity;

        // This constructor initializes ingredient details
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        //Sets the original quantity
        public void SetOriginalQuantity(double originalQuantity)
        {
            this.originalQuantity = originalQuantity;
        }

        // Resets quantity to the original value
        public void ResetQuantityToOriginal()
        {
            Quantity = originalQuantity;
        }
    }
}