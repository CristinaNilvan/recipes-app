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
        Task<List<Recipe>> GetByApprovedStatusWithPagination(PaginationParameters paginationParameters, bool approvedStatus);
        Task<List<Recipe>> GetByApprovedStatusWithoutPagination(bool approvedStatus);
        Task<List<Recipe>> GetRecipesWithIngredientAndQuantity(PaginationParameters paginationParameters, float ingredientQuantity, string ingredientName);
        Task<List<Recipe>> GetBestMatchRecipesWithIngredientAndQuantity(PaginationParameters paginationParameters, float ingredientQuantity, string ingredientName);
        Task<List<Recipe>> GetRecipesByIngredients(List<int> ingredientIds);
        //IQueryable<int> GetIngredientIdsOfRecipe(string recipeName, string recipeAuthor);
    }
}