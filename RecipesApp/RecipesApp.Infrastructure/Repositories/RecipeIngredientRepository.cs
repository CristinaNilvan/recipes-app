using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
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

        public async Task<Ingredient> GetDetailsByIngredientId(int ingredientId)
        {
            var joinQuery = await _dataContext
                .RecipeIngredients
                .Include(recipeIngredient => recipeIngredient.Ingredient)
                .Where(recipeIngredient => recipeIngredient.IngredientId == ingredientId)
                .Select(recipeIngredient => recipeIngredient.Ingredient)
                .SingleOrDefaultAsync();

            return joinQuery;
        }

        public async Task<List<RecipeIngredient>> GetByIngredientId(int ingredientId)
        {
            var query = _dataContext
                .RecipeIngredients
                .Where(recipeIngredient => recipeIngredient.IngredientId == ingredientId)
                .Select(recipeIngredient => new RecipeIngredient(recipeIngredient.Id, recipeIngredient.Quantity,
                    recipeIngredient.IngredientId));

            return await query.ToListAsync();
        }

        public async Task<RecipeIngredient> GetByQuantityAndIngredientId(float quantity, int ingredientId)
        {
            var twoDecimalQuantity = (float)Math.Round(quantity * 100f) / 100f;

            var query = await _dataContext
                .RecipeIngredients
                .SingleOrDefaultAsync(recipeIngredient =>
                    (float)Math.Round(recipeIngredient.Quantity * 100f) / 100f == twoDecimalQuantity &&
                    recipeIngredient.IngredientId == ingredientId);

            return query;
        }
    }
}