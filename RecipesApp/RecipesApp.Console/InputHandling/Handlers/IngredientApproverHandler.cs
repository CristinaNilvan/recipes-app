using RecipesApp.Application.ApproveIngredientFeature.Commands;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Console.InputHandling.Utils;

namespace RecipesApp.Console.InputHandling.Handlers
{
    internal class IngredientApproverHandler
    {
        public static async Task HandleInputFromConsole()
        {
            var mediator = MediatorSetup.GetMediator();
            var unapprovedIngredients = await mediator.Send(new GetIngredientsByApprovedStatus()
            {
                ApprovedStatus = false
            });

            System.Console.WriteLine("The unapproved ingredients are: ");
            ListPrinter.PrintList(unapprovedIngredients);

            if (unapprovedIngredients.Count == 0)
            {
                System.Console.WriteLine("No ingredients to approve!");
                return;
            }

            System.Console.WriteLine("Enter the id of the ingredient you want to approve: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            var approvedIngredient = await mediator.Send(new ApproveIngredient()
            {
                IngredientId = id
            });
        }
    }
}
