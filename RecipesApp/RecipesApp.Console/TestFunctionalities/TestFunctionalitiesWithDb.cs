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

            /*var recIng1 = mediator.Send(new GetRecipeIngredientById()
            {
                RecipeIngredientId = 4
            }).Result;

            var recIng2 = mediator.Send(new GetRecipeIngredientById()
            {
                RecipeIngredientId = 6
            }).Result;

            var recIngListNew = new List<RecipeIngredient>()
            {
                recIng2
            };*/

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

            //var recipe = mediator.Send(new DeleteRecipe() { RecipeId = 18 }).Result;

            /*var recipes = mediator.Send(new GetRecipesByApprovedStatus() { ApprovedStatus = true }).Result;

            var mealPlan = mediator.Send(new GenerateMealPlan()
            {
                Calories = 2000,
                MealType = Domain.Enums.MealType.Normal,
                Recipes = recipes
            }).Result;

            System.Console.WriteLine(mealPlan);*/

            /*var suggestedRecipes = mediator.Send(new SuggestRecipes()
            {
                IngredientName = "Ing2",
                IngredientQuantity = 300
            }).Result;

            ListPrinter.PrintList(suggestedRecipes);*/

            /*var ingList = new List<Ingredient>()
            {
                new Ingredient
                {
                    Id = 2,
                },
                new Ingredient
                {
                    Id = 8,
                }
            };

            var foundRecipes = mediator.Send(new FindRecipesByIngredients()
            {
                Ingredients = ingList
            }).Result;

            ListPrinter.PrintList(foundRecipes);*/
        }
    }
}