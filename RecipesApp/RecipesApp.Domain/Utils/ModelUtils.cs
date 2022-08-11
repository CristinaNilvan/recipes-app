namespace RecipesApp.Domain.Utils
{
    internal class ModelUtils
    {
        public static float CalculateTwoDecimalFloat(float number)
            => (float)Math.Round(number * 100f) / 100f;
    }
}
