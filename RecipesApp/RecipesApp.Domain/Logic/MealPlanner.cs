using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Domain.Logic
{
    public class MealPlanner
    {
        private readonly List<Recipe>? _allRecipes;
        private readonly List<Recipe>? _breakfastRecipes;
        private readonly List<Recipe>? _lunchRecipes;
        private readonly List<Recipe>? _dinnerRecipes;

        public MealPlanner(List<Recipe> allRecipes)
        {
            _allRecipes = new List<Recipe>(allRecipes);
            _breakfastRecipes = MealPlannerUtils.FilterByServingTime(ServingTime.Breakfast, _allRecipes);
            _lunchRecipes = MealPlannerUtils.FilterByServingTime(ServingTime.Lunch, _allRecipes);
            _dinnerRecipes = MealPlannerUtils.FilterByServingTime(ServingTime.Dinner, _allRecipes);
        }

        public MealPlan GenerateMealPlan(MealType mealType, int calories)
        {
            int averageCalories = calories / 3;

            var breakfastRecipes = MealPlannerUtils.FilterByCaloriesAndMealType(averageCalories, mealType, _breakfastRecipes);
            var lunchRecipes = MealPlannerUtils.FilterByCaloriesAndMealType(averageCalories, mealType, _lunchRecipes);
            var dinnerRecipes = MealPlannerUtils.FilterByCaloriesAndMealType(averageCalories, mealType, _dinnerRecipes);

            var random = new Random();
            var mealPlan = new MealPlan();

            mealPlan.Breakfast = breakfastRecipes.ElementAt(random.Next(0, breakfastRecipes.Count));
            mealPlan.Lunch = lunchRecipes.ElementAt(random.Next(0, lunchRecipes.Count));
            mealPlan.Dinner = dinnerRecipes.ElementAt(random.Next(0, dinnerRecipes.Count));

            return mealPlan;
        }
    }
}
