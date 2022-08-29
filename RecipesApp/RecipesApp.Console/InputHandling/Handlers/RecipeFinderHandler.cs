using RecipesApp.Application.FindRecipesByIngredientsFeature.Queries;
using RecipesApp.Console.InputHandling.Utils;

namespace RecipesApp.Console.InputHandling.Handlers
{
    internal class RecipeFinderHandler
    {
        public static async Task HandleInputFromConsole()
        {
            var ingredients = await InputHandlingUtils.CreateIngredientListForRecipeFinder();
            var mediator = MediatorSetup.GetMediator();

            var recipes = await mediator.Send(new FindRecipesByIngredients()
            {
                IngredientIds = InputHandlingUtils.GetIngredientIds(ingredients)
            });

            System.Console.WriteLine("The found recipes are: ");
            ListPrinter.PrintList(recipes);
        }
    }
}
