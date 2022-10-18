using RecipesApp.Application.Utils;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes
{
    internal class RecipeNutritionalValuesCalculator
    {
        public RecipeNutritionalValuesCalculator(float calories, float fats, float carbs, float proteins)
        {
            Calories = calories;
            Fats = fats;
            Carbs = carbs;
            Proteins = proteins;
        }

        public float Calories { get; set; }

        public float Fats { get; set; }

        public float Carbs { get; set; }

        public float Proteins { get; set; }


        public void AddRecipeIngredientNutritionalValues(RecipeWithRecipeIngredient recipeWithRecipeIngredient)
        {
            var calories = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Calories,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Calories += UsedFunctions.CalculateTwoDecimalFloat(calories);

            var fats = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Fats,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Fats += UsedFunctions.CalculateTwoDecimalFloat(fats);

            var carbs = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Carbs,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Carbs += UsedFunctions.CalculateTwoDecimalFloat(carbs);

            var proteins = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Proteins,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Proteins += UsedFunctions.CalculateTwoDecimalFloat(proteins);
        }

        public void RemoveRecipeIngredientNutritionalValues(RecipeWithRecipeIngredient recipeWithRecipeIngredient)
        {
            var calories = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Calories,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Calories -= UsedFunctions.CalculateTwoDecimalFloat(calories);

            var fats = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Fats,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Fats -= UsedFunctions.CalculateTwoDecimalFloat(fats);

            var carbs = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Carbs,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Carbs -= UsedFunctions.CalculateTwoDecimalFloat(carbs);

            var proteins = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Proteins,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Proteins -= UsedFunctions.CalculateTwoDecimalFloat(proteins);
        }

        private float CalculateNutritionalValue(float nutritionalValue, float quantity)
        {
            nutritionalValue = UsedFunctions.CalculateTwoDecimalFloat(nutritionalValue);
            quantity = UsedFunctions.CalculateTwoDecimalFloat(quantity);

            return UsedFunctions.CalculateTwoDecimalFloat(nutritionalValue * quantity / 100);
        }
    }
}
