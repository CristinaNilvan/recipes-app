using RecipesApp.Application.ApproveRecipeFeature.Commands;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Console.InputHandling.Utils;

namespace RecipesApp.Console.InputHandling.Handlers
{
    internal class RecipeApproverHandler
    {
        public static async void HandleInputFromConsole()
        {
            var mediator = MediatorSetup.GetMediator();
            var unapprovedRecipes = await mediator.Send(new GetRecipesByApprovedStatus()
            {
                ApprovedStatus = false
            });

            System.Console.WriteLine("The unapproved recipes are: ");
            ListPrinter.PrintList(unapprovedRecipes);

            if (unapprovedRecipes.Count == 0)
            {
                System.Console.WriteLine("No recipes to approve!");
                return;
            }

            System.Console.WriteLine("Enter the id of the recipe you want to approve: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            await mediator.Send(new ApproveRecipe()
            {
                RecipeId = id
            });
        }
    }
}
