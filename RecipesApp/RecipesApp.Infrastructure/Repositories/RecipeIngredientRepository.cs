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

        public async Task<Ingredient> GetIngredientDetailsById(int ingredientId)
        {
            var joinQuery = _dataContext
                .RecipeIngredients
                .Include(recipeIngredient => recipeIngredient.Ingredient)
                .Where(recipeIngredient => recipeIngredient.IngredientId == ingredientId)
                .Select(recipeIngredient => recipeIngredient.Ingredient)
                .FirstOrDefault();

            return joinQuery;
        }
    }
}