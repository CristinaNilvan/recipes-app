using MediatR;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApp.Console.InputHandling
{
    internal class InputHandlingUtils
    {
        public static Ingredient CreateIngredientFromInput()
        {
            System.Console.WriteLine("Please enter the following data: ");

            System.Console.WriteLine("Name: ");
            var name = System.Console.ReadLine();

            System.Console.WriteLine("Category [Meat, Dairy, Fruit, Vegetable, Herbs, Others]: ");
            var category = System.Console.ReadLine();
            var enumCategory = (IngredientCategory)Enum.Parse(typeof(IngredientCategory), category, true);

            System.Console.WriteLine("Calories: ");
            var calories = Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("Fats: ");
            var fats = float.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Carbs: ");
            var carbs = float.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Proteins: ");
            var proteins = float.Parse(System.Console.ReadLine());

            return new Ingredient(name, enumCategory, calories, fats, carbs, proteins);
        }

        public static List<Ingredient> CreateIngredientList()
        {
            var recipeIngredients = new List<Ingredient>();

            System.Console.WriteLine("For the ingredients you can: ");

            while (true)
            {
                System.Console.WriteLine("1 - add from current ingredients");
                System.Console.WriteLine("2 - create new ingredient");
                var choice = Convert.ToInt32(System.Console.ReadLine());

                if (choice == 1)
                {
                    IngredientHandler.HandleReadAllIngredients();
                    System.Console.WriteLine("Enter the id of the element you want to add: ");

                    var id = Convert.ToInt32(System.Console.ReadLine());
                    var element = IngredientHandler.IngredientRepository.GetIngredientById(id);

                    recipeIngredients.Add(element);
                }
                else if (choice == 2)
                {
                    var ingredient = CreateIngredientFromInput();
                    recipeIngredients.Add(ingredient);
                    IngredientHandler.IngredientRepository.CreateIngredient(ingredient);
                }

                System.Console.WriteLine("What do you want to do next? 1 - continue to add ingredients to recipe; 0 - exit");
                var nextChoice = Convert.ToInt32(System.Console.ReadLine());

                if (nextChoice == 0)
                {
                    break;
                }
            }

            return recipeIngredients;
        }
    }
}
