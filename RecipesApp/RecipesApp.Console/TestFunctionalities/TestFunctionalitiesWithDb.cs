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

            var recipes = mediator.Send(new GetIngredientsByApprovedStatus() { ApprovedStatus = true }).Result;
            ListPrinter.PrintList(recipes);

            /*var ing = mediator.Send(new UpdateIngredient()
            {
                IngredientId = 13,
                Name = "Ing13",
                Category = Domain.Enums.IngredientCategory.Meat,
                Calories = 100,
                Fats  = 50,
                Carbs = 50,
                Proteins = 50
            }).Result;*/

            /*var ings = mediator.Send(new GetAllIngredients()).Result;
            ListPrinter.PrintList(ings);*/
        }
    }
}