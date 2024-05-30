using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_POE
{
    class Recipe
    {
        // Event delegate to let user know when calories exceed 300.
        public event EventHandler CaloriesExceeded;

        public string Name { get; }
        private List<Ingredient> ingredients;
        private List<string> steps;

        // This constructor initializes recipes with a name, ingredients, and steps.
        public Recipe(string name)
        {
            Name = name;
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        // Method to add a step to the recipe
        public void AddStep(string step)
        {
            steps.Add(step);
        }

        // Method to display the recipe details
        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            int totalCalories = 0;

            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} - {ingredient.Calories} calories (Food Group: {ingredient.FoodGroup})");
                totalCalories += ingredient.Calories;
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"Step {i + 1}: {steps[i]}");
            }

            Console.WriteLine($"\nTotal Calories: {totalCalories}");
            if (totalCalories > 300)
            {
                CaloriesExceeded?.Invoke(this, EventArgs.Empty);
            }
        }

        // Method to scale the recipe by a given factor
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
                ingredient.Calories = (int)(ingredient.Calories * factor); // Adjusts calories based on the scaling factor
            }
        }

        // Resets the ingredient quantities to their original values
        public void ResetQuantities()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.ResetQuantityToOriginal();
            }
        }

        // Clears the recipe ingredients and steps.
        public void ClearRecipe()
        {
            ingredients.Clear();
            steps.Clear();
        }

        // Displays the recipe
        public void Display()
        {
            DisplayRecipe();
        }
    }
}