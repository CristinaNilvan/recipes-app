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
        Task<IQueryable<Recipe>> GetAll(PaginationParameters paginationParameters);
        Task<IQueryable<Recipe>> GetByName(PaginationParameters paginationParameters, string recipeName);
        Task<IQueryable<Recipe>> GetByApprovedStatusWithPagination(PaginationParameters paginationParameters, bool approvedStatus);
        Task<IQueryable<Recipe>> GetByApprovedStatusWithoutPagination(bool approvedStatus);
        Task<IQueryable<Recipe>> GetRecipesWithIngredientAndQuantity(PaginationParameters paginationParameters, float ingredientQuantity, string ingredientName);
        Task<IQueryable<Recipe>> GetBestMatchRecipesWithIngredientAndQuantity(PaginationParameters paginationParameters, float ingredientQuantity, string ingredientName);
        Task<IQueryable<Recipe>> GetRecipesContainingIngredients(List<int> ingredientIds);
        Task<IQueryable<int>> GetIngredientIdsByRecipeId(int recipeId);
    }
}