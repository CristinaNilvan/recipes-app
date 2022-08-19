using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.Context;

namespace RecipesApp.Infrastructure.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly DataContext _dataContext;

        public IngredientRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Ingredient> CreateIngredient(Ingredient ingredient)
        {
            _dataContext.Ingredients.Add(ingredient);
            await _dataContext.SaveChangesAsync();

            return ingredient;
        }

        public async Task<Ingredient> DeleteIngredient(int ingredientId)
        {
            var ingredient = await _dataContext.Ingredients.SingleOrDefaultAsync(x => x.Id == ingredientId);

            if (ingredient == null)
            {
                return null;
            }

            _dataContext.Ingredients.Remove(ingredient);
            await _dataContext.SaveChangesAsync();

            return ingredient;
        }

        public async Task<List<Ingredient>> GetAllIngredients()
        {
            return await _dataContext.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> GetIngredientById(int ingredientId)
        {
            return await _dataContext.Ingredients.SingleOrDefaultAsync(x => x.Id == ingredientId);
        }

        public async Task<Ingredient> GetIngredientByName(string ingredientName)
        {
            return await _dataContext.Ingredients.SingleOrDefaultAsync(x => x.Name == ingredientName);
        }

        public async Task<List<Ingredient>> GetIngredientsByApprovedStatus(bool isApproved)
        {
            return await _dataContext.Ingredients.Where(x => x.Approved == isApproved).ToListAsync();
        }

        public async Task<Ingredient> UpdateIngredient(Ingredient newIngredient)
        {
            if (newIngredient == null)
            {
                return null;
            }

            _dataContext.Ingredients.Update(newIngredient);
            await _dataContext.SaveChangesAsync();

            return newIngredient;
        }

        public Task UpdateIngredientStatus(int ingredientId, bool status)
        {
            throw new NotImplementedException();
        }
    }
}
