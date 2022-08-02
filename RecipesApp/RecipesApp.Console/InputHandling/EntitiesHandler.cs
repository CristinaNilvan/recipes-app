using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Console.InputHandling
{
    internal class EntitiesHandler
    {
        private static List<Ingredient> ingredients = new List<Ingredient>(PopulateLists.PopulateIngredients());
        private static List<Recipe> recipes = new List<Recipe>(PopulateLists.PopulateRecipes());

        public static List<Ingredient> Ingredients => ingredients;
        public static List<Recipe> Recipes => recipes;

        public static void HandleInputFromConsole(int entity, int operation)
        {
            if (entity == 1)
            {
                DoIngredientOperation(operation);
            }
            else if (entity == 2)
            {
                DoRecipeOperation(operation);
            }
        }

        private static void DoIngredientOperation(int operation)
        {
            switch (operation)
            {
                case 1:
                    IngredientHandler.HandleCreateIngredient();
                    break;
                case 2:
                    IngredientHandler.HandleReadIngredient();
                    break;
                case 3:
                    IngredientHandler.HandleUpdateIngredient();
                    break;
                case 4:
                    IngredientHandler.HandleDeleteIngredient();
                    break;
                case 5:
                    IngredientHandler.HandleReadIngredients();
                    break;
                default:
                    System.Console.WriteLine("Invalid number for operation!");
                    break;
            }
        }

        private static void DoRecipeOperation(int operation)
        {
            if (operation == 1)
            {
                var recipe = RecipeHandler.HandleCreateRecipe();

                if (recipe != null)
                {
                    System.Console.WriteLine("Recipe created successfully!");
                    recipes.Add(recipe);
                }
                else
                    System.Console.WriteLine("Something went wrong!");
            }

            if (operation == 2)
            {
                RecipeHandler.HandleReadRecipes(recipes);
            }

            if (operation == 3)
            {
                RecipeHandler.HandleUpdateRecipe(recipes);

                System.Console.WriteLine("The list after the update: ");
                ListPrinter.PrintList(recipes);
            }

            if (operation == 4)
            {
                RecipeHandler.HandleDeleteRecipe(recipes);

                System.Console.WriteLine("The list after the deletion: ");
                ListPrinter.PrintList(recipes);
            }
        }
    }
}
