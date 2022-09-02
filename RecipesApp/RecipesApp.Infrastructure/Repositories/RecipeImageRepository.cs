using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions.Repositories;
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

        public async Task<RecipeImage> GetByRecipeId(int recipeId)
        {
            return await _dataContext
                .RecipeImages
                .SingleOrDefaultAsync(x => x.RecipeId == recipeId);
        }
    }
}
