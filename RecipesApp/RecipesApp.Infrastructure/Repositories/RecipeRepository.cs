﻿using MediatR;
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

        public async Task<Recipe> CreateRecipe(Recipe recipe, List<RecipeIngredient> recipeIngredients)
        {
            _dataContext.Recipes.Add(recipe);
            await _dataContext.SaveChangesAsync();

            var recipeAfterInsertion = await GetRecipeByName(recipe.Name);

            foreach (var recipeIngredient in recipeIngredients)
            {
                var auxRecipeIng = _dataContext.RecipeIngredients.Find(recipeIngredient.Id);

                var recipeWithRecipeIngredient = new RecipeWithRecipeIngredient
                {
                    RecipeId = recipeAfterInsertion.Id,
                    Recipe = recipe,
                    RecipeIngredientId = auxRecipeIng.Id,
                    RecipeIngredient = auxRecipeIng
                };

                _dataContext.RecipeWithRecipeIngredients.Add(recipeWithRecipeIngredient);
                await _dataContext.SaveChangesAsync();
            }

            return recipe;
        }

        public async Task<Recipe> DeleteRecipe(int recipeId)
        {
            var recipe = await _dataContext.Recipes.SingleOrDefaultAsync(x => x.Id == recipeId);

            if (recipe == null)
            {
                return null;
            }

            _dataContext.Recipes.Remove(recipe);
            await _dataContext.SaveChangesAsync();

            return recipe;
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

        public async Task<Recipe> UpdateRecipeStatus(int recipeId, bool status)
        {
            var recipe = await _dataContext.Recipes.SingleOrDefaultAsync(x => x.Id == recipeId);

            recipe.Approved = status;
            await _dataContext.SaveChangesAsync();

            return recipe;
        }
    }
}
