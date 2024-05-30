//I utilised W3schools quite a bit but also few other resources that will follow as comment.
//https://www.w3schools.com/cs/cs_arrays.php
//https://www.w3schools.com/cs/cs_user_input.php
//https://www.w3schools.com/cs/cs_booleans.php
//https://www.w3schools.com/cs/cs_booleans.php
//https://www.w3schools.com/cs/cs_properties.php
//https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_POE
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is the main menu selection page.
            Console.WriteLine("Welcome to Your Recipe App!");

            RecipeManager recipeManager = new RecipeManager();

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add a new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Display a specific recipe");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRecipe(recipeManager);
                        break;
                    case "2":
                        recipeManager.DisplayAllRecipes();
                        break;
                    case "3":
                        DisplaySpecificRecipe(recipeManager);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
        //This is for recipe management, from the name to the calories to ingredients.
        static void AddRecipe(RecipeManager recipeManager)
        {
            Console.Write("Please enter the name of the recipe: ");
            string recipeName = Console.ReadLine();

            Recipe recipe = new Recipe(recipeName);
            recipe.CaloriesExceeded += Recipe_CaloriesExceeded;

            Console.Write("Please enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter the quantity of {name}: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"Enter the unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                Console.Write("Enter the number of calories: ");
                int calories = int.Parse(Console.ReadLine());

                Console.Write("Enter the food group: ");
                string foodGroup = Console.ReadLine();

                Ingredient ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
                ingredient.SetOriginalQuantity(quantity);
                recipe.AddIngredient(ingredient);
            }

            Console.Write("Now, enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();

                recipe.AddStep(step);
            }

            recipeManager.AddRecipe(recipe);
            Console.WriteLine("Recipe added successfully!");
            recipe.DisplayRecipe();

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Scale Recipe");
            Console.WriteLine("2. View Original Quantities");
            Console.WriteLine("3. Clear Recipe");
            Console.WriteLine("4. Exit to main menu");

            bool exit = false;
            while (!exit)
            {
                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter scale factor (0.5, 2, or 3): ");
                        double scaleFactor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(scaleFactor);
                        recipe.DisplayRecipe();
                        break;
                    case 2:
                        recipe.ResetQuantities();
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        recipe.ClearRecipe();
                        Console.WriteLine("Recipe data cleared.");
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        static void Recipe_CaloriesExceeded(object sender, EventArgs e)
        {
            Console.WriteLine("Warning: This recipe exceeds 300 calories.");
        }

        static void DisplaySpecificRecipe(RecipeManager recipeManager)
        {
            recipeManager.DisplayAllRecipes();
            Console.WriteLine("Enter the name of the recipe you want to view:");
            string name = Console.ReadLine();

            Recipe recipe = recipeManager.GetRecipeByName(name);
            if (recipe != null)
            {
                recipe.Display();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
    }
}