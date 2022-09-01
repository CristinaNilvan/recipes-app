using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IRecipeIngredientRepository
    {
        Task Create(RecipeIngredient recipeIngredient);
        Task<RecipeIngredient> GetById(int recipeIngredientId);
        Task<List<RecipeIngredient>> GetByIngredientId(int ingredientId);
        Task<RecipeIngredient> GetByQuantityAndIngredientId(float quantity, int ingredientId);
    }
}