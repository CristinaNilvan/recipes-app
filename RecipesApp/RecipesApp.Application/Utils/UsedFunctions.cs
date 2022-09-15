namespace RecipesApp.Application.Utils
{
    internal class UsedFunctions
    {
        public static float CalculateTwoDecimalFloat(float number)
            => (float)Math.Round(number * 100f) / 100f;
    }
}