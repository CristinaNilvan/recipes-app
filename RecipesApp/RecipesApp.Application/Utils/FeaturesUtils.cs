using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Utils
{
    internal class FeaturesUtils
    {
        public static float CalculateTwoDecimalFloat(float number)
            => (float)Math.Round(number * 100f) / 100f;

        public static List<Recipe> FilterByMealType(MealType mealType, List<Recipe> recipes)
            => recipes.Where(recipe => recipe.MealType == mealType).ToList();

        public static List<Recipe> FilterByCaloriesAndMealType(float calories, MealType mealType, List<Recipe> recipes)
            => recipes.Where(recipe => recipe.Calories <= calories && recipe.MealType == mealType).ToList();

        public static List<Recipe> FilterByServingTime(ServingTime servingTime, List<Recipe> recipes)
            => recipes.Where(recipe => recipe.ServingTime == servingTime).ToList();

        public static List<Recipe> GetRecipesForMealPlan(float calories, MealType mealType, List<Recipe> recipes)
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

        public static bool CheckIfRecipeContainsAllIngredients(List<int> recipeIngredientList,
            List<int> givenIngredientList)
            => givenIngredientList
                .All(givenItem => recipeIngredientList
                .Any(recipeIngredientItem => givenItem == recipeIngredientItem));

        public static List<Recipe> DoPaginationOnRecipes(List<Recipe> recipes, PaginationParameters paginationParameters)
        {
            return recipes
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToList();
        }
    }
}
