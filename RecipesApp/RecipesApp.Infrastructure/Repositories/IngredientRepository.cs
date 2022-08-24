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

        public async Task CreateIngredient(Ingredient ingredient)
        {
            await _dataContext.Ingredients.AddAsync(ingredient);
        }

        public async Task DeleteIngredient(Ingredient ingredient)
        {
            _dataContext.Ingredients.Remove(ingredient);
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

        public async Task UpdateIngredient(Ingredient ingredient)
        {
            //_dataContext.Ingredients.Update(ingredient);

            var ingredientToUpdate = await _dataContext.Ingredients.SingleOrDefaultAsync(x => x.Id == ingredient.Id);

            ingredientToUpdate.Name = ingredient.Name;
            ingredientToUpdate.Calories = ingredient.Calories;
            ingredientToUpdate.Fats = ingredient.Fats;
            ingredientToUpdate.Carbs = ingredient.Carbs;
            ingredientToUpdate.Proteins = ingredient.Proteins;
            ingredientToUpdate.Approved = ingredient.Approved;
        }

        public async Task UpdateIngredientStatus(Ingredient ingredient, bool status)
        {
            ingredient.Approved = status;
        }
    }
}
