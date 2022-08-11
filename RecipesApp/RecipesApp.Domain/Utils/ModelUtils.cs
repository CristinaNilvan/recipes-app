using RecipesApp.Domain.Models;

namespace RecipesApp.Domain.Utils
{
    internal class ModelUtils
    {
        public static float CalculateTwoDecimalFloat(float number)
            => (float)Math.Round(number * 100f) / 100f; 

        public static float CalculateNutritionalValue(float nutritionalValue, float quantity)
        {
            nutritionalValue = CalculateTwoDecimalFloat(nutritionalValue);
            quantity = CalculateTwoDecimalFloat(quantity);

            return (nutritionalValue * quantity) / 100;
        }
    }
}