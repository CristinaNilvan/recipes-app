using MediatR;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Console.InputHandling.Utils;

namespace RecipesApp.Console.InputHandling.Handlers
{
    internal class RecipeHandler
    {
        private static readonly IMediator _mediator = MediatorSetup.GetMediator();

        public async static void HandleCreateRecipe()
        {
            var recipe = InputHandlingUtils.CreateRecipeFromInput();

            await _mediator.Send(new CreateRecipe()
            {
                Name = recipe.Name,
                Author = recipe.Author,
                Description = recipe.Description,
                MealType = recipe.MealType,
                ServingTime = recipe.ServingTime,
                Ingredients = recipe.Ingredients
            });
        }

        public static async void HandleReadRecipe()
        {
            System.Console.WriteLine("Please enter the id: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            var recipe = await _mediator.Send(new GetRecipeById()
            {
                RecipeId = id
            });

            System.Console.WriteLine(recipe);
        }

        public static async void HandleUpdateRecipe()
        {
            HandleReadAllRecipes();

            System.Console.WriteLine("Enter the id of the element you want to update: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            var recipe = InputHandlingUtils.CreateRecipeFromInput();

            await _mediator.Send(new UpdateRecipe()
            {
                RecipeId = id,
                Name = recipe.Name,
                Author = recipe.Author,
                Description = recipe.Description,
                MealType = recipe.MealType,
                ServingTime = recipe.ServingTime,
                Ingredients = recipe.Ingredients
            });
        }

        public static async void HandleDeleteRecipe()
        {
            HandleReadAllRecipes();

            System.Console.WriteLine("Enter the id of the element you want to delete: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            await _mediator.Send(new DeleteRecipe()
            {
                RecipeId = id
            });
        }

        public static async void HandleReadAllRecipes()
        {
            System.Console.WriteLine("Here are the current recipes: ");
            var recipes = await _mediator.Send(new GetRecipesByApprovedStatus() 
            { 
                ApprovedStatus = true
            });

            ListPrinter.PrintList(recipes);
        }
    }
}
