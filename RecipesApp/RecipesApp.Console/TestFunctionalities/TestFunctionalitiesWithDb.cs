using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Console.InputHandling.Utils;

namespace RecipesApp.Console.TestFunctionalities
{
    internal class TestFunctionalitiesWithDb
    {
        public static void TestGetAllIngredientsWithNewMediator()
        {
            var mediator = NewMediatorSetup.GetMediator();
            var recipes = mediator.Send(new GetRecipesByApprovedStatus() { ApprovedStatus = true }).Result;

            var recipe = mediator.Send(new GetRecipeByName() { RecipeName = "Rec2" }).Result;

            ListPrinter.PrintList(recipes);
            System.Console.WriteLine();
            System.Console.WriteLine(recipe);
        }
    }
}