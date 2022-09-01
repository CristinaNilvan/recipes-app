using MediatR;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Console.InputHandling.Utils;
using RecipesApp.Domain.Enums;

namespace RecipesApp.Console.InputHandling.Handlers
{
    internal class RecipeHandler
    {
        private static readonly IMediator _mediator = MediatorSetup.GetMediator();

        public async static Task HandleCreateRecipe()
        {
            System.Console.WriteLine("Please enter the following data: ");

            System.Console.WriteLine("Name: ");
            var name = System.Console.ReadLine();

            System.Console.WriteLine("Author: ");
            var author = System.Console.ReadLine();

            System.Console.WriteLine("Decription: ");
            var description = System.Console.ReadLine();

            System.Console.WriteLine("Meal Type [Normal, Vegetarian, Vegan]: ");
            var mealType = System.Console.ReadLine();
            var enumMealType = (MealType)Enum.Parse(typeof(MealType), mealType, true);

            System.Console.WriteLine("Serving Time [Breakfast, Lunch, Dinner, Others]: ");
            var servingTime = System.Console.ReadLine();
            var enumServingTime = (ServingTime)Enum.Parse(typeof(ServingTime), servingTime, true);

            System.Console.WriteLine("Number of servings: ");
            var servings = float.Parse(System.Console.ReadLine());

            var recipeIngredients = await InputHandlingUtils.CreateIngredientListForRecipe();

            await _mediator.Send(new CreateRecipe()
            {
                Name = name,
                Author = author,
                Description = description,
                MealType = enumMealType,
                ServingTime = enumServingTime,
                Servings = servings,
                RecipeIngredients = recipeIngredients
            });
        }

        public static async Task HandleReadRecipe()
        {
            System.Console.WriteLine("Please enter the id: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            var recipe = await _mediator.Send(new GetRecipeById()
            {
                RecipeId = id
            });

            System.Console.WriteLine(recipe);
        }

        public static async Task HandleUpdateRecipe()
        {
            await HandleReadAllRecipes();

            System.Console.WriteLine("Enter the id of the recipe you want to update: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("Name: ");
            var name = System.Console.ReadLine();

            System.Console.WriteLine("Author: ");
            var author = System.Console.ReadLine();

            System.Console.WriteLine("Decription: ");
            var description = System.Console.ReadLine();

            System.Console.WriteLine("Meal Type [Normal, Vegetarian, Vegan]: ");
            var mealType = System.Console.ReadLine();
            var enumMealType = (MealType)Enum.Parse(typeof(MealType), mealType, true);

            System.Console.WriteLine("Serving Time [Breakfast, Lunch, Dinner, Others]: ");
            var servingTime = System.Console.ReadLine();
            var enumServingTime = (ServingTime)Enum.Parse(typeof(ServingTime), servingTime, true);

            System.Console.WriteLine("Number of servings: ");
            var servings = float.Parse(System.Console.ReadLine());

            var recipeIngredients = await InputHandlingUtils.CreateIngredientListForRecipe();

            await _mediator.Send(new UpdateRecipe()
            {
                Id = id,
                Name = name,
                Author = author,
                Description = description,
                MealType = enumMealType,
                ServingTime = enumServingTime,
                Servings = servings,
                RecipeIngredients = recipeIngredients
            });
        }

        public static async Task HandleDeleteRecipe()
        {
            await HandleReadAllRecipes();

            System.Console.WriteLine("Enter the id of the recipe you want to delete: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            await _mediator.Send(new DeleteRecipe()
            {
                RecipeId = id
            });
        }

        public static async Task HandleReadAllRecipes()
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
