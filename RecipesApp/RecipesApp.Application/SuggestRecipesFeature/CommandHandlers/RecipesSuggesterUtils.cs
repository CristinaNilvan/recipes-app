namespace RecipesApp.Application.SuggestRecipesFeature.CommandHandlers
{
    public class RecipesSuggesterUtils
    {
        public static float CalculateTwoDecimalFloat(float number)
            => (float)Math.Round(number * 100f) / 100f;

    }
}
