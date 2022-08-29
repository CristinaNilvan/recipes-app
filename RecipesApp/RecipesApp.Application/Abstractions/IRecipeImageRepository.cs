using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IRecipeImageRepository
    {
        Task Create(RecipeImage recipeImage);
        Task Delete(RecipeImage recipeImage);
    }
}
