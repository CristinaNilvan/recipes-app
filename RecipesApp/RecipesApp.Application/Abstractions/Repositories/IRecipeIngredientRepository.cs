using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions.Repositories
{
    public interface IRecipeIngredientRepository
    {
        Task Create(RecipeIngredient recipeIngredient);
        Task<RecipeIngredient> GetById(int recipeIngredientId);
        Task<RecipeIngredient> GetByQuantityAndIngredientId(float quantity, int ingredientId);
    }
}