using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.Context;

namespace RecipesApp.Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DataContext _dataContext;

        public RecipeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task CreateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecipe(int recipeId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            return await _dataContext.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetRecipeById(int recipeId)
        {
            return await _dataContext.Recipes.SingleOrDefaultAsync(x => x.Id == recipeId);
        }

        public async Task<Recipe> GetRecipeByName(string recipeName)
        {
            return await _dataContext.Recipes.SingleOrDefaultAsync(x => x.Name == recipeName);
        }

        public async Task<List<Recipe>> GetRecipesByApprovedStatus(bool isApproved)
        {
            return await _dataContext.Recipes.Where(x => x.Approved == isApproved).ToListAsync();
        }

        public Task UpdateRecipe(Recipe newRecipe)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRecipe(int recipeId, Recipe newRecipe)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRecipeStatus(int recipeId, bool status)
        {
            throw new NotImplementedException();
        }
    }
}
