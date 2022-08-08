using RecipesApp.Application.MealPlannerFeature.Commands;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Console.InputHandling.Utils;
using RecipesApp.Domain.Enums;

namespace RecipesApp.Console.InputHandling.Handlers
{
    internal class MealPlannerHandler
    {
        public static async void HandleInputFromConsole()
        {
            System.Console.WriteLine("Please enter the following data: ");

            System.Console.WriteLine("Meal Type [Normal, Vegetarian, Vegan]: ");
            var readMealType = System.Console.ReadLine();
            var enumMealType = (MealType)Enum.Parse(typeof(MealType), readMealType, true);

            System.Console.WriteLine("Total number of calories: ");
            var calories = Convert.ToInt32(System.Console.ReadLine());

            var mediator = MediatorSetup.GetMediator();
            var allRecipes = await mediator.Send(new GetAllRecipes());

            var mealPlan = await mediator.Send(new GenerateMealPlan()
            {
                MealType = enumMealType,
                Calories = calories,
                Recipes = allRecipes
            });

            System.Console.WriteLine("The meal plan is: ");
            System.Console.WriteLine(mealPlan);
        }
    }
}