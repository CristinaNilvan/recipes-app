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
                    Id = 4,
                    Quantity = 100,
                    IngredientId = 5
                },
                /*new RecipeIngredient()
                {
                    Id = 3,
                    Quantity = 200,
                    IngredientId = 2
                },*/
            };

            var recipe = await mediator.Send(new CreateRecipe()
            {
                Name = "Rec18",
                Author = "Cristina Nilvan",
                Description = "Desc",
                MealType = Domain.Enums.MealType.Normal,
                ServingTime = Domain.Enums.ServingTime.Dinner,
                Servings = 5,
                RecipeIngredients = recIngList
            });

            System.Console.WriteLine(recipe);
        }
    }
}