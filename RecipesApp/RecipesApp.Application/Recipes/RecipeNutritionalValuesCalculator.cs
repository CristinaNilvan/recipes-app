using RecipesApp.Application.Utils;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes
{
    internal class RecipeNutritionalValuesCalculator
    {
        public RecipeNutritionalValuesCalculator(Recipe recipe)
        {
            Recipe = recipe;
        }

        public Recipe Recipe { get; set; }

        public void AddRecipeIngredientNutritionalValues(RecipeWithRecipeIngredient recipeWithRecipeIngredient)
        {
            var calories = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Calories,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Recipe.Calories += UsedFunctions.CalculateTwoDecimalFloat(calories);

            var fats = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Fats,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Recipe.Fats += UsedFunctions.CalculateTwoDecimalFloat(fats);

            var carbs = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Carbs,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Recipe.Carbs += UsedFunctions.CalculateTwoDecimalFloat(carbs);

            var proteins = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Proteins,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Recipe.Proteins += UsedFunctions.CalculateTwoDecimalFloat(proteins);
        }

        public void RemoveRecipeIngredientNutritionalValues(RecipeWithRecipeIngredient recipeWithRecipeIngredient)
        {
            var calories = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Calories,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Recipe.Calories -= UsedFunctions.CalculateTwoDecimalFloat(calories);

            var fats = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Fats,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Recipe.Fats -= UsedFunctions.CalculateTwoDecimalFloat(fats);

            var carbs = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Carbs,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Recipe.Carbs -= UsedFunctions.CalculateTwoDecimalFloat(carbs);

            var proteins = CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Proteins,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
            Recipe.Proteins -= UsedFunctions.CalculateTwoDecimalFloat(proteins);
        }

        private float CalculateNutritionalValue(float nutritionalValue, float quantity)
        {
            nutritionalValue = UsedFunctions.CalculateTwoDecimalFloat(nutritionalValue);
            quantity = UsedFunctions.CalculateTwoDecimalFloat(quantity);

            return UsedFunctions.CalculateTwoDecimalFloat(nutritionalValue * quantity / 100);
        }
    }
}
