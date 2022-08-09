using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IIngredientRepository
    {
        void CreateIngredient(Ingredient ingredient);
        Ingredient GetIngredientById(int ingredientId);
        Ingredient GetIngredientByName(string ingredientName);
        void UpdateIngredient(int ingredientId, Ingredient newIngredient);
        void UpdateIngredientStatus(int ingredientId, bool status);
        void DeleteIngredient(int ingredientId);
        List<Ingredient> GetAllIngredients();
        List<Ingredient> GetIngredientsByApprovedStatus(bool isApproved);
    }
}
