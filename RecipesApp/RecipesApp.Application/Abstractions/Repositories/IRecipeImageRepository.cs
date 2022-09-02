using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions.Repositories
{
    public interface IRecipeImageRepository
    {
        Task Create(RecipeImage recipeImage);
        Task<RecipeImage> GetByRecipeId(int recipeId);
        Task Delete(RecipeImage recipeImage);
    }
}
