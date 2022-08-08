using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Console.InputHandling.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
