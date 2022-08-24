using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IRecipeRepository
    {
        Task CreateRecipe(Recipe recipe);
        Task<Recipe> GetRecipeById(int recipeId);
        Task<Recipe> GetRecipeByName(string recipeName);
        Task UpdateRecipe(Recipe recipe);
        Task UpdateRecipeStatus(Recipe recipe, bool status);
        Task DeleteRecipe(Recipe recipe);
        Task<List<Recipe>> GetAllRecipes();
        Task<List<Recipe>> GetRecipesByApprovedStatus(bool isApproved);
        Task<List<Recipe>> GetRecipesWithInredientAndQuantity(float ingredientQuantity, string ingredientName);
        Task<List<Recipe>> GetBestMatchRecipesWithInredientAndQuantity(float ingredientQuantity, string ingredientName);
        Task<List<int>> GetIngredientIdsOfRecipe(string recipeName, string recipeAuthor);
    }
}