﻿using RecipesApp.Application.Abstractions;
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
    }
}
