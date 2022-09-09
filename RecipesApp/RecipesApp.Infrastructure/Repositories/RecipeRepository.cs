using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions.Repositories;
using RecipesApp.Domain.Enums;
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
                .ThenInclude(recWithRecIngs => recWithRecIngs.RecipeIngredient)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize);
        }

        public async Task<Recipe> GetById(int recipeId)
        {
            return await _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeImage)
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recWithRecIngs => recWithRecIngs.RecipeIngredient)
                .SingleOrDefaultAsync(recipe => recipe.Id == recipeId);
        }

        public async Task<IQueryable<Recipe>> GetByName(PaginationParameters paginationParameters, string recipeName)
        {
            return _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeImage)
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recWithRecIngs => recWithRecIngs.RecipeIngredient)
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
                .ThenInclude(recWithRecIngs => recWithRecIngs.RecipeIngredient)
                .Where(recipe => recipe.Approved == approvedStatus)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize);
        }

        public async Task<IQueryable<Recipe>> GetByMealPlannerCriteria(float calories, MealType mealType, ServingTime servingTime)
        {
            var query = _dataContext
                .Recipes
                .Include(recipe => recipe.RecipeImage)
                .Include(recipe => recipe.RecipeWithRecipeIngredients)
                .ThenInclude(recWithRecIngs => recWithRecIngs.RecipeIngredient)
                .Where(recipe => recipe.Calories <= calories &&
                    recipe.MealType == mealType &&
                    recipe.ServingTime == servingTime &&
                    recipe.Approved == true);

            return query;
        }

        public async Task<IQueryable<Recipe>> GetByIngredientAndQuantity(PaginationParameters paginationParameters,
            float ingredientQuantity, string ingredientName)
        {
            var joinQuery = _dataContext
                .RecipeWithRecipeIngredients
                .Where(recWithRecIngs =>
                    recWithRecIngs.RecipeIngredient.Quantity <= ingredientQuantity &&
                    recWithRecIngs.RecipeIngredient.Ingredient.Name == ingredientName &&
                    recWithRecIngs.Recipe.Approved == true)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .Select(outerRecWithRecIngs => _dataContext
                    .Recipes
                    .Include(recipe => recipe.RecipeImage)
                    .Include(recipe => recipe.RecipeWithRecipeIngredients)
                    .ThenInclude(innerRecWithRecIngs => innerRecWithRecIngs.RecipeIngredient)
                    .SingleOrDefault(recipe => recipe.Id == outerRecWithRecIngs.Recipe.Id));

            return joinQuery;
        }

        public async Task<IQueryable<Recipe>> GetBestMatchByIngredientAndQuantity(PaginationParameters paginationParameters,
            float ingredientQuantity, string ingredientName)
        {
            var quantityLimit = ingredientQuantity / 2;

            var joinQuery = _dataContext
                .RecipeWithRecipeIngredients
                .Where(recWithRecIngs =>
                    recWithRecIngs.RecipeIngredient.Quantity <= ingredientQuantity &&
                    recWithRecIngs.RecipeIngredient.Quantity >= quantityLimit &&
                    recWithRecIngs.RecipeIngredient.Ingredient.Name == ingredientName &&
                    recWithRecIngs.Recipe.Approved == true)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .Select(outerRecWithRecIngs => _dataContext
                    .Recipes
                    .Include(recipe => recipe.RecipeImage)
                    .Include(recipe => recipe.RecipeWithRecipeIngredients)
                    .ThenInclude(innerRecWithRecIngs => innerRecWithRecIngs.RecipeIngredient)
                    .SingleOrDefault(recipe => recipe.Id == outerRecWithRecIngs.Recipe.Id));

            return joinQuery;
        }

        public async Task<IQueryable<Recipe>> GetByContainingOneOfGivenIngredients(List<int> ingredientIds)
        {
            var joinQuery = _dataContext
                .RecipeWithRecipeIngredients
                .Where(recWithRecIng => ingredientIds.Contains(recWithRecIng.RecipeIngredient.IngredientId) &&
                    recWithRecIng.Recipe.Approved == true)
                .Select(outerRecWithRecIngs => _dataContext
                    .Recipes
                    .Include(recipe => recipe.RecipeImage)
                    .Include(recipe => recipe.RecipeWithRecipeIngredients)
                    .ThenInclude(innerRecWithRecIngs => innerRecWithRecIngs.RecipeIngredient)
                    .SingleOrDefault(recipe => recipe.Id == outerRecWithRecIngs.Recipe.Id));

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
