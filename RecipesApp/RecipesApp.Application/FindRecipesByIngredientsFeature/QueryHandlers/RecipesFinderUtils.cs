using RecipesApp.Domain.Models;

namespace RecipesApp.Application.FindRecipesByIngredientsFeature.QueryHandlers
{
    internal class RecipesFinderUtils
    {
        public static List<int> GetIngredientIds(List<Ingredient> ingredients)
            => ingredients.Select(x => x.Id).ToList();

        public static bool CheckIfRecipeContainsAllIngredients(List<int> recipeIngredientList, 
            List<int> givenIngredientList)
            => givenIngredientList.All(x => recipeIngredientList.Any(y => x == y));
    }
}