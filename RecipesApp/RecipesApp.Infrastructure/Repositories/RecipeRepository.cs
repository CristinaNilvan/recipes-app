using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions.Repositories;
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

        public async Task<List<Recipe>> GetAll(PaginationParameters paginationParameters)
        {
            return await _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeImage)
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync();
        }

        public async Task<Recipe> GetById(int recipeId)
        {
            return await _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeImage)
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .SingleOrDefaultAsync(recipe => recipe.Id == recipeId);
        }

        public async Task<List<Recipe>> GetByName(PaginationParameters paginationParameters, string recipeName)
        {
            return await _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeImage)
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Where(recipe => recipe.Name == recipeName)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync(); ;
        }

        public async Task<List<Recipe>> GetByApprovedStatus(PaginationParameters paginationParameters, bool approvedStatus)
        {
            var getByApproveStatusQuery = _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeImage)
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Where(recipe => recipe.Approved == approvedStatus);

            if (paginationParameters.PageNumber > 0)
            {
                getByApproveStatusQuery = getByApproveStatusQuery
                    .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                    .Take(paginationParameters.PageSize);
            }

            return await getByApproveStatusQuery.ToListAsync();
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
                    .Include(recipe => recipe.RecipeImage)
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
                    .Include(recipe => recipe.RecipeImage)
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
