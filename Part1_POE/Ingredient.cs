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
        private double originalQuantity;

        public void SetOriginalQuantity(double originalQuantity)
        {
            this.originalQuantity = originalQuantity;
        }

        public void ResetQuantityToOriginal()
        {
            Quantity = originalQuantity;
        }
    }
}