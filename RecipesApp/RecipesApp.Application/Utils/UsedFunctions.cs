namespace RecipesApp.Application.Utils
{
    internal class UsedFunctions
    {
        public static float CalculateTwoDecimalFloat(float number)
            => (float)Math.Round(number * 100f) / 100f;

        public static bool CheckIfRecipeContainsAllIngredients(List<int> recipeIngredientList,
            List<int> givenIngredientList)
            => givenIngredientList
                .All(givenItem => recipeIngredientList
                .Any(recipeIngredientItem => givenItem == recipeIngredientItem));
    }
}