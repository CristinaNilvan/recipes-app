using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IRecipeIngredientRepository
    {
        Task<RecipeIngredient> CreateRecipeIngredient(RecipeIngredient recipeIngredient);
    }
}
