using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions.Repositories
{
    public interface IRecipeWithRecipeIngredientsRepository
    {
        Task DeleteByRecipeId(int recipeId);
        Task<RecipeWithRecipeIngredient> GetByRecipeIdAndRecipeIngredientId(int recipeId, int recipeIngredientId);
    }
}
