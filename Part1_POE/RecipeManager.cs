using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_POE
{
    internal class RecipeManager
    {
        // List to store recipes
        private List<Recipe> recipes = new List<Recipe>();

        // Method to add a recipe to the list
        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        // Display all recipes sorted by name
        public void DisplayAllRecipes()
        {
            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            Console.WriteLine("Recipes:");
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        // Method to get a recipe by its name
        public Recipe GetRecipeByName(string name)
        {
            return recipes.FirstOrDefault(r => r.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}