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

        public async Task<IQueryable<Recipe>> GetAll(PaginationParameters paginationParameters)
        {
            return _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeImage)
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize);
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

        public async Task<IQueryable<Recipe>> GetByName(PaginationParameters paginationParameters, string recipeName)
        {
            return _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeImage)
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Where(recipe => recipe.Name == recipeName)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize);
        }

        public async Task<IQueryable<Recipe>> GetByApprovedStatusWithPagination(PaginationParameters paginationParameters, bool approvedStatus)
        {
            return _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeImage)
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Where(recipe => recipe.Approved == approvedStatus)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize);
        }

        public async Task<IQueryable<Recipe>> GetByApprovedStatusWithoutPagination(bool approvedStatus)
        {
            return _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeImage)
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Where(recipe => recipe.Approved == approvedStatus);
        }

        // to delete
        public async Task Update(Recipe recipe)
        {
            _dataContext.Recipes.Update(recipe);
        }

        // to delete
        public async Task UpdateApprovedStatus(Recipe recipe, bool status)
        {
            recipe.Approved = status;
        }

        public async Task<IQueryable<Recipe>> GetRecipesWithIngredientAndQuantity(PaginationParameters paginationParameters,
            float ingredientQuantity, string ingredientName)
        {
            //remove includes
            var joinQuery = _dataContext
                .RecipeWithRecipeIngredients
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.Recipe)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient.Ingredient)
                .Where(recipeWithRecipeIngredients =>
                    recipeWithRecipeIngredients.RecipeIngredient.Quantity <= ingredientQuantity &&
                    recipeWithRecipeIngredients.RecipeIngredient.Ingredient.Name == ingredientName &&
                    recipeWithRecipeIngredients.Recipe.Approved == true)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .Select(recipeWithRecipeIngredientsOuter => _dataContext
                    .Recipes
                    .Include(recipe => recipe.RecipeImage)
                    .Include(recipe => recipe.RecipeWithRecipeIngredients)
                    .ThenInclude(recipeWithRecipeIngredientInner => recipeWithRecipeIngredientInner.RecipeIngredient)
                    .SingleOrDefault(recipe => recipe.Id == recipeWithRecipeIngredientsOuter.Recipe.Id));

            return joinQuery;
        }

        public async Task<IQueryable<Recipe>> GetBestMatchRecipesWithIngredientAndQuantity(PaginationParameters paginationParameters,
            float ingredientQuantity, string ingredientName)
        {
            var quantityLimit = ingredientQuantity / 2;

            //remove includes
            var joinQuery = _dataContext
                .RecipeWithRecipeIngredients
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.Recipe)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient.Ingredient)
                .Where(recipeWithRecipeIngredients =>
                    recipeWithRecipeIngredients.RecipeIngredient.Quantity <= ingredientQuantity &&
                    recipeWithRecipeIngredients.RecipeIngredient.Quantity >= quantityLimit &&
                    recipeWithRecipeIngredients.RecipeIngredient.Ingredient.Name == ingredientName &&
                    recipeWithRecipeIngredients.Recipe.Approved == true)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .Select(recipeWithRecipeIngredientsOuter => _dataContext
                    .Recipes
                    .Include(recipe => recipe.RecipeImage)
                    .Include(recipe => recipe.RecipeWithRecipeIngredients)
                    .ThenInclude(recipeWithRecipeIngredientInner => recipeWithRecipeIngredientInner.RecipeIngredient)
                    .SingleOrDefault(recipe => recipe.Id == recipeWithRecipeIngredientsOuter.Recipe.Id));

            return joinQuery;
        }

        public async Task<IQueryable<Recipe>> GetRecipesContainingIngredients(List<int> ingredientIds)
        {
            var joinQuery = _dataContext
                .RecipeWithRecipeIngredients
                .Include(recWithRecIng => recWithRecIng.Recipe)
                .Where(recWithRecIng => ingredientIds.Contains(recWithRecIng.RecipeIngredient.IngredientId))
                .Select(recWithRecIngOut => _dataContext
                    .Recipes
                    .Include(recipe => recipe.RecipeImage)
                    .Include(recipe => recipe.RecipeWithRecipeIngredients)
                    .ThenInclude(recipeWithRecipeIngredientInner => recipeWithRecipeIngredientInner.RecipeIngredient)
                    .SingleOrDefault(recipe => recipe.Id == recWithRecIngOut.Recipe.Id));

            return joinQuery;
        }

        public async Task<IQueryable<int>> GetIngredientIdsByRecipeId(int recipeId)
        {
            var joinQuery = _dataContext
                .RecipeWithRecipeIngredients
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.Recipe)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Where(recipeWithRecipeIngredients =>
                    recipeWithRecipeIngredients.RecipeId == recipeId)
                .Select(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient.IngredientId);

            return joinQuery;
        }
    }
}
