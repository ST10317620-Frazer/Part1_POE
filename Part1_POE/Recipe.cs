using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_POE
{
    class Recipe
    {
        private Ingredient[] ingredients;
        private string[] steps;

        public Recipe(int numIngredients, int numSteps)
        {
            ingredients = new Ingredient[numIngredients];
            steps = new string[numSteps];
        }

        public void SetIngredient(int index, string name, double quantity, string unit) // This helps the storage of original values.
        {
            ingredients[index] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
            ingredients[index].SetOriginalQuantity(quantity);
        }

        public void SetStep(int index, string description)
        {
            steps[index] = description;
        }

        public void DisplayRecipe() //handles display.
        {
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor < 1 ? factor : 1 / factor;
            }
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.ResetQuantityToOriginal();
            }
        }

        public void ClearRecipe() // This clears the recipe and steps
        {
            Array.Clear(ingredients, 0, ingredients.Length);
            Array.Clear(steps, 0, steps.Length);
        }
    }
}