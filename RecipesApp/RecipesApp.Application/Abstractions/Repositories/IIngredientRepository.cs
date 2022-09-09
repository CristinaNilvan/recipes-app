using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions.Repositories
{
    public interface IIngredientRepository
    {
        Task Create(Ingredient ingredient);
        Task<Ingredient> GetById(int ingredientId);
        Task<Ingredient> GetByName(string ingredientName);
        Task Delete(Ingredient ingredient);
        Task<IQueryable<Ingredient>> GetAll(PaginationParameters paginationParameters);
        Task<IQueryable<Ingredient>> GetByApprovedStatus(PaginationParameters paginationParameters, bool approvedStatus);
    }
}
