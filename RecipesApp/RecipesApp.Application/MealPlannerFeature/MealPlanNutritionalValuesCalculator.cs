using RecipesApp.Application.Utils;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.MealPlannerFeature
{
    internal class MealPlanNutritionalValuesCalculator
    {
        public MealPlanNutritionalValuesCalculator(MealPlan mealPlan)
        {
            MealPlan = mealPlan;
        }

        public MealPlan MealPlan { get; set; }

        public void CalculateNutritionalValues()
        {
            var calories = MealPlan.Breakfast.Calories + MealPlan.Lunch.Calories + MealPlan.Dinner.Calories;
            MealPlan.Calories = UsedFunctions.CalculateTwoDecimalFloat(calories);

            var fats = MealPlan.Breakfast.Fats + MealPlan.Lunch.Fats + MealPlan.Dinner.Fats;
            MealPlan.Fats = UsedFunctions.CalculateTwoDecimalFloat(fats);

            var carbs = MealPlan.Breakfast.Carbs + MealPlan.Lunch.Carbs + MealPlan.Dinner.Carbs;
            MealPlan.Carbs = UsedFunctions.CalculateTwoDecimalFloat(carbs);

            var proteins = MealPlan.Breakfast.Proteins + MealPlan.Lunch.Proteins + MealPlan.Dinner.Proteins;
            MealPlan.Proteins = UsedFunctions.CalculateTwoDecimalFloat(proteins);
        }
    }
}
