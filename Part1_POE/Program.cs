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
            Console.WriteLine("Welcome to Your Recipe App!");// A welcome for the user.

            // This asks the user for the number of ingredients and steps
            Console.Write("Please enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            Console.Write("now, enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            Recipe recipe = new Recipe(numIngredients, numSteps);

            // This is the process it takes to inout the ingredients.
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter the quantity of {name}: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"Enter the unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                recipe.SetIngredient(i, name, quantity, unit);
            }

            // User will input instruction steps for the recipe.
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();

                recipe.SetStep(i, step);
            }

            recipe.DisplayRecipe();

            // This shows options to the user ,it shows up after the recipe is displayed.
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Scale Recipe");
            Console.WriteLine("2. View Original Quantities");
            Console.WriteLine("3. Clear Recipe");
            Console.WriteLine("4. Exit app");

            bool exit = false;//This is for data management.
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
    }
}