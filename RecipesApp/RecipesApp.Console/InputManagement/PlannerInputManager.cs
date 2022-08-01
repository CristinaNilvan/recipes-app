using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;
using RecipesApp.Console.Logic;

namespace RecipesApp.Console.InputManagement
{
    internal class PlannerInputManager
    {
        private static List<MealPlan> mealPlans = new List<MealPlan>();

        public static List<MealPlan> MealPlans => mealPlans;

        public static void HandleInputFromConsole()
        {
            System.Console.WriteLine("Please enter the following data: ");

            System.Console.WriteLine("Meal Type [Normal, Vegetarian, Vegan]: ");
            var readMealType = System.Console.ReadLine();
            var enumMealType = (MealType)Enum.Parse(typeof(MealType), readMealType, true);

            System.Console.WriteLine("Total number of calories: ");
            var calories = Convert.ToInt32(System.Console.ReadLine());

            var planner = new MealPlanner(EntitiesInputManager.Recipes);
            var mealPlan = planner.GenerateMealPlan(enumMealType, calories);
            mealPlans.Add(mealPlan);

            System.Console.WriteLine("The meal plan is: ");
            System.Console.WriteLine(mealPlan);
        }
    }
}