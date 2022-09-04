using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions.Repositories;
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

        public async Task Create(Ingredient ingredient)
        {
            await _dataContext
                .Ingredients
                .AddAsync(ingredient);
        }

        public async Task Delete(Ingredient ingredient)
        {
            _dataContext
                .Ingredients
                .Remove(ingredient);
        }

        public async Task<List<Ingredient>> GetAll(PaginationParameters paginationParameters)
        {
            return await _dataContext
                .Ingredients
                .Include(ingredient => ingredient.IngredientImage)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync();
        }

        public async Task<Ingredient> GetById(int ingredientId)
        {
            return await _dataContext
                .Ingredients
                .Include(ingredient => ingredient.IngredientImage)
                .Include(ingredient => ingredient.RecipeIngredients)
                .SingleOrDefaultAsync(ingredient => ingredient.Id == ingredientId);
        }

        public async Task<Ingredient> GetByName(string ingredientName)
        {
            return await _dataContext
                .Ingredients
                .Include(ingredient => ingredient.IngredientImage)
                .SingleOrDefaultAsync(ingredient => ingredient.Name == ingredientName);
        }

        public async Task<List<Ingredient>> GetByApprovedStatus(PaginationParameters paginationParameters, bool approvedStatus)
        {
            return await _dataContext
                .Ingredients
                .Include(ingredient => ingredient.IngredientImage)
                .Where(ingredient => ingredient.Approved == approvedStatus)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync();
        }

        public async Task Update(Ingredient ingredient)
        {
            _dataContext
                .Ingredients
                .Update(ingredient);
        }

        public async Task UpdateApprovedStatus(Ingredient ingredient, bool status)
        {
            ingredient.Approved = status;
        }
    }
}
