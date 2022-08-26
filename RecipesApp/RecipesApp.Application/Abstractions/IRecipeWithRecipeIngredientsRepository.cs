using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IRecipeWithRecipeIngredientsRepository
    {
        Task DeleteRecipeIngredientsByRecipeId(int recipeId);
        Task<RecipeWithRecipeIngredient> GetByRecipeIdAndRecipeIngredientId(int recipeId, int recipeIngredientId);
    }
}
