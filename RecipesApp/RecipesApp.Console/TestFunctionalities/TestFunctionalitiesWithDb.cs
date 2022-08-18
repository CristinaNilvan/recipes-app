using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Console.InputHandling.Utils;

namespace RecipesApp.Console.TestFunctionalities
{
    internal class TestFunctionalitiesWithDb
    {
        public static void TestGetAllIngredientsWithNewMediator()
        {
            var mediator = NewMediatorSetup.GetMediator();
            var ingredient = mediator.Send(new UpdateIngredient()
            {
                IngredientId = 16,
                Name = "Ing14",
                Category = Domain.Enums.IngredientCategory.Fruit,
                Calories = 80,
                Fats = 50,
                Carbs = 50,
                Proteins = 50
            }).Result;

            System.Console.WriteLine(ingredient);
        }
    }
}