using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;
using RecipesApp.Domain.Logic;
using RecipesApp.Application.MealPlannerFeature.Commands;
using RecipesApp.Application.Recipes.Queries;

namespace RecipesApp.Console.InputHandling
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

            var recipeMediator = MediatorSetup.GetMediator();
            var allRecipes = await recipeMediator.Send(new GetAllRecipes());

            var mealPlanMediator = MediatorSetup.GetMediator();
            var mealPlan = await mealPlanMediator.Send(new GenerateMealPlan()
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