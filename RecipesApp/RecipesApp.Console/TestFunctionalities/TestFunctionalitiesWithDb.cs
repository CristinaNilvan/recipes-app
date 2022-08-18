using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Console.InputHandling.Utils;

namespace RecipesApp.Console.TestFunctionalities
{
    internal class TestFunctionalitiesWithDb
    {
        public static void TestGetAllIngredientsWithNewMediator()
        {
            var mediator = NewMediatorSetup.GetMediator();
            var ingredientList = mediator.Send(new GetAllIngredients()).Result;
            ListPrinter.PrintList(ingredientList);

            System.Console.WriteLine();

            var ingredientList2 = mediator.Send(new GetIngredientsByApprovedStatus() { ApprovedStatus = true }).Result;
            ListPrinter.PrintList(ingredientList2);
        }
    }
}