using RecipesApp.Application.SuggestRecipesFeature.Queries;
using RecipesApp.Console.InputHandling.Utils;

namespace RecipesApp.Console.InputHandling.Handlers
{
    internal class RecipeSuggesterHandler
    {
        public static async Task HandleInputFromConsole()
        {
            System.Console.WriteLine("Please enter the following data: ");

            System.Console.WriteLine("The name of the ingredient you have: ");
            var name = System.Console.ReadLine();

            System.Console.WriteLine("The quantity of the ingredient you have: ");
            var quantity = float.Parse(System.Console.ReadLine());

            var mediator = MediatorSetup.GetMediator();
            var recipes = await mediator.Send(new SuggestRecipes()
            {
                IngredientName = name,
                IngredientQuantity = quantity
            });

            System.Console.WriteLine("The best matches are: ");
            ListPrinter.PrintList(recipes);
        }
    }
}
