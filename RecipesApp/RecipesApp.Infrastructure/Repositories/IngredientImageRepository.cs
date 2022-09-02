using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions.Repositories;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.Context;

namespace RecipesApp.Infrastructure.Repositories
{
    public class IngredientImageRepository : IIngredientImageRepository
    {
        private readonly DataContext _dataContext;

        public IngredientImageRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(IngredientImage ingredientImage)
        {
            await _dataContext
                .IngredientImages
                .AddAsync(ingredientImage);
        }

        public async Task Delete(IngredientImage ingredientImage)
        {
            _dataContext
                .IngredientImages
                .Remove(ingredientImage);
        }

        public async Task<IngredientImage> GetByIngredientId(int ingredientId)
        {
            return await _dataContext
                .IngredientImages
                .SingleOrDefaultAsync(x => x.IngredientId == ingredientId);
        }
    }
}
