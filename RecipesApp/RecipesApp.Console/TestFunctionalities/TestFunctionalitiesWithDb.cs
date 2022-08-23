﻿namespace RecipesApp.Console.TestFunctionalities
{
    internal class TestFunctionalitiesWithDb
    {
        public static void TestMediators()
        {
            var mediator = NewMediatorSetup.GetMediator();

            /*var recIngList = new List<RecipeIngredient>
            {
                new RecipeIngredient()
                {
                    Id = 1,
                    Quantity = 500,
                    IngredientId = 3
                },
            };

            var recipe = mediator.Send(new CreateRecipe()
            {
                Name = "Rec16",
                Author = "Cristina Nilvan",
                Description = "Desc",
                MealType = Domain.Enums.MealType.Normal,
                ServingTime = Domain.Enums.ServingTime.Dinner,
                Servings = 5,
                RecipeIngredients = recIngList
            }).Result;

            System.Console.WriteLine(recipe);
*/
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