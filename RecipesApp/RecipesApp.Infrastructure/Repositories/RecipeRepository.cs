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

        public async Task Create(Recipe recipe)
        {
            await _dataContext
                .Recipes
                .AddAsync(recipe);
        }

        public async Task Delete(Recipe recipe)
        {
            _dataContext
                .Recipes
                .Remove(recipe);
        }

        public async Task<List<Recipe>> GetAll()
        {
            return await _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .ToListAsync();
        }

        public async Task<Recipe> GetById(int recipeId)
        {
            return await _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .SingleOrDefaultAsync(x => x.Id == recipeId);
        }

        public async Task<List<Recipe>> GetByName(string recipeName)
        {
            return await _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Where(x => x.Name == recipeName)
                .ToListAsync(); ;
        }

        public async Task<List<Recipe>> GetByApprovedStatus(bool approvedStatus)
        {
            return await _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Where(x => x.Approved == approvedStatus)
                .ToListAsync();
        }

        public async Task Update(Recipe recipe)
        {
            _dataContext.Recipes.Update(recipe);
        }

        public async Task UpdateApprovedStatus(Recipe recipe, bool status)
        {
            recipe.Approved = status;
        }

        public async Task<List<Recipe>> GetRecipesWithInredientAndQuantity(float ingredientQuantity, string ingredientName)
        {
            var joinQuery = _dataContext
                .RecipeWithRecipeIngredients
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.Recipe)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient.Ingredient)
                .Where(recipeWithRecipeIngredients =>
                    recipeWithRecipeIngredients.RecipeIngredient.Quantity <= ingredientQuantity &&
                    recipeWithRecipeIngredients.RecipeIngredient.Ingredient.Name == ingredientName)
                .Select(recipeWithRecipeIngredientsOuter => _dataContext
                    .Recipes
                    .Include(recipe => recipe.RecipeWithRecipeIngredients)
                    .ThenInclude(recipeWithRecipeIngredientInner => recipeWithRecipeIngredientInner.RecipeIngredient)
                    .SingleOrDefault(recipe => recipe.Id == recipeWithRecipeIngredientsOuter.Recipe.Id));

            return await joinQuery.ToListAsync();
        }

        public async Task<List<Recipe>> GetBestMatchRecipesWithInredientAndQuantity(float ingredientQuantity, string ingredientName)
        {
            var quantityLimit = ingredientQuantity / 2;

            var joinQuery = _dataContext
                .RecipeWithRecipeIngredients
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.Recipe)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient.Ingredient)
                .Where(recipeWithRecipeIngredients =>
                    recipeWithRecipeIngredients.RecipeIngredient.Quantity <= ingredientQuantity &&
                    recipeWithRecipeIngredients.RecipeIngredient.Quantity >= quantityLimit &&
                    recipeWithRecipeIngredients.RecipeIngredient.Ingredient.Name == ingredientName)
                .Select(recipeWithRecipeIngredientsOuter => _dataContext
                    .Recipes
                    .Include(recipe => recipe.RecipeWithRecipeIngredients)
                    .ThenInclude(recipeWithRecipeIngredientInner => recipeWithRecipeIngredientInner.RecipeIngredient)
                    .SingleOrDefault(recipe => recipe.Id == recipeWithRecipeIngredientsOuter.Recipe.Id));

            return await joinQuery.ToListAsync();
        }

        public async Task<List<int>> GetIngredientIdsOfRecipe(string recipeName, string recipeAuthor)
        {
            var joinQuery = _dataContext
                .RecipeWithRecipeIngredients
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.Recipe)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Where(recipeWithRecipeIngredients =>
                    recipeWithRecipeIngredients.Recipe.Name == recipeName &&
                    recipeWithRecipeIngredients.Recipe.Author == recipeAuthor)
                .Select(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient.IngredientId);

            return await joinQuery.ToListAsync();
        }
    }
}
