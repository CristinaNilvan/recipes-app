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
    internal class RecipeInputManager
    {
        public static Recipe HandleCreateRecipe()
        {
            return null;
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

            RecipeCRUDOperations.Update(recipes, recipes.ElementAt(number - 1), recipe);
        }

        public static void HandleDeleteRecipe(List<Recipe> recipes)
        {
            HandleReadRecipes(recipes);

            System.Console.WriteLine("Enter the number of the element you want to delete: ");
            var number = Convert.ToInt32(System.Console.ReadLine());

            RecipeCRUDOperations.Delete(recipes, recipes.ElementAt(number - 1));
        }
    }
}
