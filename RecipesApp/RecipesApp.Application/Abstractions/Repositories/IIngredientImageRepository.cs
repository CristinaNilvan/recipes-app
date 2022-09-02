using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions.Repositories
{
    public interface IIngredientImageRepository
    {
        Task Create(IngredientImage ingredientImage);
        Task<IngredientImage> GetByIngredientId(int ingredientId);
        Task Delete(IngredientImage ingredientImage);
    }
}