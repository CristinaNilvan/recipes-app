using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.MealPlannerFeature.CommandHandlers
{
    public class MealPlannerUtils
    {
        public static float CalculateTwoDecimalFloat(float number)
            => (float)Math.Round(number * 100f) / 100f;

        public static List<Recipe> FilterByMealType(MealType mealType, List<Recipe> recipes)
            => recipes.Where(recipe => recipe.MealType == mealType).ToList();

        public static List<Recipe> FilterByCaloriesAndMealType(float calories, MealType mealType, List<Recipe> recipes)
            => recipes.Where(recipe => recipe.Calories <= calories && recipe.MealType == mealType).ToList();

        public static List<Recipe> FilterByServingTime(ServingTime servingTime, List<Recipe> recipes)
            => recipes.Where(recipe => recipe.ServingTime == servingTime).ToList();

        public static List<Recipe> GetRecipes(float calories, MealType mealType, List<Recipe> recipes)
        {
            var bestMatches = FilterByCaloriesAndMealType(calories, mealType, recipes);
            var recipesByMealType = FilterByMealType(mealType, recipes);

            if (bestMatches.Count != 0)
            {
                return bestMatches;
            }
            else if (recipesByMealType.Count != 0)
            {
                return recipesByMealType;
            }
            else
            {
                return recipes;
            }
        }
    }
}
