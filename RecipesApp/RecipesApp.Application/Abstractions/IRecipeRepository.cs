using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IRecipeRepository
    {
        Task<Recipe> CreateRecipe(Recipe recipe, List<RecipeIngredient> recipeIngredients);
        Task<Recipe> GetRecipeById(int recipeId);
        Task<Recipe> GetRecipeByName(string recipeName);
        Task UpdateRecipe(Recipe newRecipe);
        Task UpdateRecipe(int recipeId, Recipe newRecipe);
        Task<Recipe> UpdateRecipeStatus(int recipeId, bool status);
        Task<Recipe> DeleteRecipe(int recipeId);
        Task<List<Recipe>> GetAllRecipes();
        Task<List<Recipe>> GetRecipesByApprovedStatus(bool isApproved);
    }
}