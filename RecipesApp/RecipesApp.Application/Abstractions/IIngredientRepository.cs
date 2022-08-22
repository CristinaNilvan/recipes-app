using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IIngredientRepository
    {
        Task<Ingredient> CreateIngredient(Ingredient ingredient);
        Task<Ingredient> GetIngredientById(int ingredientId);
        Task<Ingredient> GetIngredientByName(string ingredientName);
        Task<Ingredient> UpdateIngredient(Ingredient newIngredient);
        Task<Ingredient> UpdateIngredientStatus(int ingredientId, bool status);
        Task<Ingredient> DeleteIngredient(int ingredientId);
        Task<List<Ingredient>> GetAllIngredients();
        Task<List<Ingredient>> GetIngredientsByApprovedStatus(bool isApproved);
    }
}
