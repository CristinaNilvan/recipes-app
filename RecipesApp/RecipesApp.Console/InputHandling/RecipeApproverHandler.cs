using RecipesApp.Application.ApproveRecipeFeature.Commands;
using RecipesApp.Application.Recipes.Queries;

namespace RecipesApp.Console.InputHandling
{
    internal class RecipeApproverHandler
    {
        public static async void HandleInputFromConsole()
        {
            var mediator = MediatorSetup.GetMediator();
            var unapprovedRecipes = await mediator.Send(new GetUnapprovedRecipes());

            System.Console.WriteLine("The unapproved recipes are: ");
            ListPrinter.PrintList(unapprovedRecipes);

            System.Console.WriteLine("Enter the id of the recipe you want to approve: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            await mediator.Send(new ApproveRecipe()
            {
                RecipeId = id
            });
        }
    }
}
