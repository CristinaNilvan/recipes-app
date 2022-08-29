using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.Context;

namespace RecipesApp.Infrastructure.Repositories
{
    public class RecipeImageRepository : IRecipeImageRepository
    {
        private readonly DataContext _dataContext;

        public RecipeImageRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(RecipeImage recipeImage)
        {
            await _dataContext
                .RecipeImages
                .AddAsync(recipeImage);
        }

        public async Task Delete(RecipeImage recipeImage)
        {
            _dataContext
                .RecipeImages
                .Remove(recipeImage);
        }
    }
}
