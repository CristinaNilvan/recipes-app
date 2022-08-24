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

        public async Task CreateRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            await _dataContext.RecipeIngredients.AddAsync(recipeIngredient);
        }

        public async Task<RecipeIngredient> GetRecipeIngredientById(int recipeIngredientId)
        {
            return await _dataContext.RecipeIngredients.SingleOrDefaultAsync(x => x.Id == recipeIngredientId);
        }

        public async Task<Ingredient> GetRecipeIngredientDetailsByIngredientId(int ingredientId)
        {
            var joinQuery = _dataContext
                .RecipeIngredients
                .Include(recipeIngredient => recipeIngredient.Ingredient)
                .Where(recipeIngredient => recipeIngredient.IngredientId == ingredientId)
                .Select(recipeIngredient => recipeIngredient.Ingredient)
                .FirstOrDefault();

            return joinQuery;
        }

        public async Task<List<RecipeIngredient>> GetRecipeIngredietsByIngredientId(int ingredientId)
        {
            var query = _dataContext
                .RecipeIngredients
                .Where(recipeIngredient => recipeIngredient.IngredientId == ingredientId)
                .Select(recipeIngredient => new RecipeIngredient(recipeIngredient.Id, recipeIngredient.Quantity, 
                    recipeIngredient.IngredientId));

            return await query.ToListAsync();
        }

        public async Task<RecipeIngredient> GetRecipeIngredientByQuantityAndIngredientId(float quantity, int ingredientId)
        {
            var twoDecimalQuantity = (float)Math.Round(quantity * 100f) / 100f;

            var query = _dataContext
                .RecipeIngredients
                .Where(recipeIngredient =>
                    (float)Math.Round(recipeIngredient.Quantity * 100f) / 100f == twoDecimalQuantity &&
                    recipeIngredient.IngredientId == ingredientId)
                .FirstOrDefault();

            return query;
        }
    }
}