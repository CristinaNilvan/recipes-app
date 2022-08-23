using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IRecipeIngredientRepository
    {
        Task CreateRecipeIngredient(RecipeIngredient recipeIngredient);
    }
}
