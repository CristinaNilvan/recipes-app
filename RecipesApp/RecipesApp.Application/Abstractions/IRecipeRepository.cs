using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IRecipeRepository
    {
        Task<Recipe> CreateRecipe(Recipe recipe, List<RecipeIngredient> recipeIngredients);
        Task<Recipe> GetRecipeById(int recipeId);
        Task<Recipe> GetRecipeByName(string recipeName);
        Task<Recipe> UpdateRecipe(Recipe newRecipe, List<RecipeIngredient> recipeIngredients);
        Task<Recipe> UpdateRecipeStatus(int recipeId, bool status);
        Task<Recipe> DeleteRecipe(int recipeId);
        Task<List<Recipe>> GetAllRecipes();
        Task<List<Recipe>> GetRecipesByApprovedStatus(bool isApproved);
        Task<List<Recipe>> GetRecipesWithInredientAndQuantity(float ingredientQuantity, string ingredientName);
        Task<List<Recipe>> GetBestMatchRecipesWithInredientAndQuantity(float ingredientQuantity, string ingredientName);
        Task<List<int>> GetIngredientIdsOfRecipe(string recipeName, string recipeAuthor);
    }
}