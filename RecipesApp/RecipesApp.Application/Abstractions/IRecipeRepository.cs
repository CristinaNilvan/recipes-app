using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IRecipeRepository
    {
        void CreateRecipe(Recipe recipe);
        Recipe GetRecipeById(int recipeId);
        Recipe GetRecipeByName(string recipeName);
        void UpdateRecipe(int recipeId, Recipe newRecipe);
        void DeleteRecipe(int recipeId);
        void AddIngredientToRecipe(int recipeId, Ingredient ingredient);
        void DeleteIngredientFromRecipe(int recipeId, int ingredientId);
        List<Recipe> GetAllRecipes();
        List<Recipe> GetRecipesByIngredients(List<Ingredient> ingredients);
    }
}