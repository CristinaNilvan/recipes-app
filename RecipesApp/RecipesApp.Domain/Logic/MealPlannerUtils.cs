using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Domain.Logic
{
    public class MealPlannerUtils
    {
        public static List<Recipe> FilterByCalories(int calories, List<Recipe> recipes)
            => recipes.Where(recipe => recipe.Calories <= calories).ToList();

        public static List<Recipe> FilterByMealType(MealType mealType, List<Recipe> recipes)
            => recipes.Where(recipe => recipe.Type.MealType == mealType).ToList();

        public static List<Recipe> FilterByServingTime(ServingTime servingTime, List<Recipe> recipes)
            => recipes.Where(recipe => recipe.Type.ServingTime == servingTime).ToList();
    }
}
