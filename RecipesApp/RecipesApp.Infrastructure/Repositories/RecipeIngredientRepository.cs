using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions.Repositories;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.Context;

namespace RecipesApp.Infrastructure.Repositories
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private readonly DataContext _dataContext;

        public RecipeIngredientRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(RecipeIngredient recipeIngredient)
        {
            await _dataContext
                .RecipeIngredients
                .AddAsync(recipeIngredient);
        }

        public async Task<RecipeIngredient> GetById(int recipeIngredientId)
        {
            return await _dataContext
                .RecipeIngredients
                .Include(recipeIngredient => recipeIngredient.Ingredient)
                .SingleOrDefaultAsync(x => x.Id == recipeIngredientId);
        }
    }
}