﻿using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Console.InputHandling.Utils;

namespace RecipesApp.Console.InputHandling.Handlers
{
    internal class RecipeFinderHandler
    {
        public static async void HandleInputFromConsole()
        {
            var ingredients = InputHandlingUtils.CreateIngredientListForRecipeFinder().Result;
            var mediator = MediatorSetup.GetMediator();
            var recipes = await mediator.Send(new GetRecipesByIngredients()
            {
                Ingredients = ingredients
            });

            System.Console.WriteLine("The found recipes are: ");
            ListPrinter.PrintList(recipes);
        }
    }
}
