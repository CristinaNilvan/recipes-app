using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Console.TestFunctionalities
{
    internal class TestFunctionalitiesWithDb
    {
        public static async Task TestMediators()
        {
            var mediator = NewMediatorSetup.GetMediator();

            var recIngList = new List<RecipeIngredient>
            {
                new RecipeIngredient()
                {
                    Id = 2,
                    Quantity = 300,
                    IngredientId = 3
                },
                new RecipeIngredient()
                {
                    Id = 3,
                    Quantity = 200,
                    IngredientId = 2
                },
            };

            var recipe = await mediator.Send(new UpdateRecipe()
            {
                RecipeId = 15,
                Name = "Test Rec",
                Author = "Cristina Nilvan",
                Description = "Desc",
                MealType = Domain.Enums.MealType.Normal,
                ServingTime = Domain.Enums.ServingTime.Lunch,
                Servings = 5,
                RecipeIngredients = recIngList
            });

            System.Console.WriteLine(recipe);
        }
    }
}