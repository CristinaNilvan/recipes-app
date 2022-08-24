using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IRecipeIngredientRepository
    {
        Task CreateRecipeIngredient(RecipeIngredient recipeIngredient);
        Task<Ingredient> GetRecipeIngredientDetailsByIngredientId(int ingredientId);
        Task<RecipeIngredient> GetRecipeIngredientById(int recipeIngredientId);
        Task<List<RecipeIngredient>> GetRecipeIngredietsByIngredientId(int ingredientId);
        Task<RecipeIngredient> GetRecipeIngredientByQuantityAndIngredientId(float quantity, int ingredientId);
    }
}