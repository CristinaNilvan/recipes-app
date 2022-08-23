using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IIngredientRepository
    {
        Task CreateIngredient(Ingredient ingredient);
        Task<Ingredient> GetIngredientById(int ingredientId);
        Task<Ingredient> GetIngredientByName(string ingredientName);
        Task UpdateIngredient(Ingredient ingredient);
        Task UpdateIngredientStatus(Ingredient ingredient, bool status);
        Task DeleteIngredient(Ingredient ingredient);
        Task<List<Ingredient>> GetAllIngredients();
        Task<List<Ingredient>> GetIngredientsByApprovedStatus(bool isApproved);
    }
}
