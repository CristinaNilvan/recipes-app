namespace RecipesApp.Application.FindRecipesByIngredientsFeature.QueryHandlers
{
    internal class RecipesFinderUtils
    {
        public static bool CheckIfRecipeContainsAllIngredients(List<int> recipeIngredientList,
            List<int> givenIngredientList)
            => givenIngredientList.All(x => recipeIngredientList.Any(y => x == y));
    }
}