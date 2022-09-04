using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions.Repositories
{
    public interface IRecipeRepository
    {
        Task Create(Recipe recipe);
        Task<Recipe> GetById(int recipeId);
        Task Update(Recipe recipe);
        Task UpdateApprovedStatus(Recipe recipe, bool status);
        Task Delete(Recipe recipe);
        Task<List<Recipe>> GetAll(PaginationParameters paginationParameters);
        Task<List<Recipe>> GetByName(PaginationParameters paginationParameters, string recipeName);
        Task<List<Recipe>> GetByApprovedStatus(PaginationParameters paginationParameters, bool approvedStatus);
        Task<List<Recipe>> GetRecipesWithInredientAndQuantity(float ingredientQuantity, string ingredientName);
        Task<List<Recipe>> GetBestMatchRecipesWithInredientAndQuantity(float ingredientQuantity, string ingredientName);
        Task<List<int>> GetIngredientIdsOfRecipe(string recipeName, string recipeAuthor);
    }
}