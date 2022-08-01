using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Console.CRUD;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Console.InputHandling
{
    internal class RecipeHandler
    {
        public static Recipe HandleCreateRecipe()
        {
            System.Console.WriteLine("Please enter the following data: ");

            System.Console.WriteLine("Id: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

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

            return RecipeCRUD.Create(id, name, author, description, new RecipeType(enumMealType, enumServingTime),
                CreateIngredientList());
        }

        public static void HandleReadRecipes(List<Recipe> recipes)
        {
            System.Console.WriteLine("Here are the current recipes: ");
            ListPrinter.PrintList(recipes);
        }

        public static void HandleUpdateRecipe(List<Recipe> recipes)
        {
            HandleReadRecipes(recipes);

            System.Console.WriteLine("Enter the number of the element you want to update: ");
            var number = Convert.ToInt32(System.Console.ReadLine());
            var recipe = HandleCreateRecipe();

            RecipeCRUD.Update(recipes, recipes.ElementAt(number - 1), recipe);
        }

        public static void HandleDeleteRecipe(List<Recipe> recipes)
        {
            HandleReadRecipes(recipes);

            System.Console.WriteLine("Enter the number of the element you want to delete: ");
            var number = Convert.ToInt32(System.Console.ReadLine());

            RecipeCRUD.Delete(recipes, recipes.ElementAt(number - 1));
        }

        private static List<Ingredient> CreateIngredientList()
        {
            var recipeIngredients = new List<Ingredient>();

            System.Console.WriteLine("For the ingredients you can: add from current ingredients or create new ingredient");

            while (true)
            {
                System.Console.WriteLine("1 - add from current ingredients");
                System.Console.WriteLine("2 - create new ingredient");
                var choice = Convert.ToInt32(System.Console.ReadLine());

                if (choice == 1)
                {
                    IngredientHandler.HandleReadIngredients(EntitiesHandler.Ingredients);
                    System.Console.WriteLine("Enter the number of the element you want to add: ");
                    var number = Convert.ToInt32(System.Console.ReadLine());
                    var element = EntitiesHandler.Ingredients.ElementAt(number - 1);
                    recipeIngredients.Add(element);
                }
                else if (choice == 2)
                {
                    var ingredient = IngredientHandler.HandleCreateIngredient();
                    recipeIngredients.Add(ingredient);
                    EntitiesHandler.Ingredients.Add(ingredient);
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
