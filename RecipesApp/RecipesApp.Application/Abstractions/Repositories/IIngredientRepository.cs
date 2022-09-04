using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions.Repositories
{
    public interface IIngredientRepository
    {
        Task Create(Ingredient ingredient);
        Task<Ingredient> GetById(int ingredientId);
        Task<Ingredient> GetByName(string ingredientName);
        Task Update(Ingredient ingredient);
        Task UpdateApprovedStatus(Ingredient ingredient, bool status);
        Task Delete(Ingredient ingredient);
        Task<List<Ingredient>> GetAll(PaginationParameters paginationParameters);
        Task<List<Ingredient>> GetByApprovedStatus(PaginationParameters paginationParameters, bool approvedStatus);
    }
}
