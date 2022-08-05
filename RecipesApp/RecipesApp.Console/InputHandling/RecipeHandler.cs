using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.InMemoryRepositories;

namespace RecipesApp.Console.InputHandling
{
    internal class RecipeHandler
    {
        private static InMemoryRecipeRepository _repository = new InMemoryRecipeRepository();

        public static InMemoryRecipeRepository RecipeRepository => _repository;

        public static void HandleCreateRecipe()
        {
            _repository.CreateRecipe(CreateRecipeFromInput());
        }

        public static void HandleReadRecipe()
        {
            System.Console.WriteLine("Please enter the id: ");
            var id = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine(_repository.GetRecipeById(id));
        }

        public static void HandleUpdateRecipe()
        {
            HandleReadRecipes();

            System.Console.WriteLine("Enter the id of the element you want to update: ");
            var id = Convert.ToInt32(System.Console.ReadLine());
            var recipe = CreateRecipeFromInput();

            _repository.UpdateRecipe(id, recipe);
        }

        public static void HandleDeleteRecipe()
        {
            HandleReadRecipes();

            System.Console.WriteLine("Enter the id of the element you want to delete: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            _repository.DeleteRecipe(id);
        }

        public static void HandleReadRecipes()
        {
            System.Console.WriteLine("Here are the current recipes: ");
            ListPrinter.PrintList(_repository.Recipes);
        }

        private static Recipe CreateRecipeFromInput()
        {
            System.Console.WriteLine("Please enter the following data: ");

            System.Console.WriteLine("Name: ");
            var name = System.Console.ReadLine();

            System.Console.WriteLine("Author: ");
            var author = System.Console.ReadLine();

            System.Console.WriteLine("Decription: ");
            var description = System.Console.ReadLine();

            System.Console.WriteLine("Meal Type [Normal, Vegetarian, Vegan]: ");
            var mealType = System.Console.ReadLine();
            var enumMealType = (MealType)Enum.Parse(typeof(MealType), mealType, true);

            System.Console.WriteLine("Serving Time [Breakfast, Lunch, Dinner]: ");
            var servingTime = System.Console.ReadLine();
            var enumServingTime = (ServingTime)Enum.Parse(typeof(ServingTime), servingTime, true);

            return new Recipe(name, author, description, enumMealType, enumServingTime, CreateIngredientList());
        }

        private static List<Ingredient> CreateIngredientList()
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
                    var ingredient = IngredientHandler.CreateIngredientFromInput();
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
