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

        public async Task CreateRecipe(Recipe recipe)
        {
            await _dataContext.Recipes.AddAsync(recipe);
        }

        public async Task DeleteRecipe(Recipe recipe)
        {
            _dataContext.Recipes.Remove(recipe);
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

        //to update
        public async Task UpdateRecipe(Recipe recipe)
        {
            _dataContext.Recipes.Update(recipe);
        }

        public async Task UpdateRecipeStatus(Recipe recipe, bool status)
        {
            recipe.Approved = status;
        }

        public async Task<List<Recipe>> GetRecipesWithInredientAndQuantity(float ingredientQuantity, string ingredientName)
        {
            /*var joinQuery =
                from recipe in _dataContext.Recipes
                join recipeWithRecipeIngredients in _dataContext.RecipeWithRecipeIngredients
                    on recipe.Id equals recipeWithRecipeIngredients.RecipeId
                join recipeIngredient in _dataContext.RecipeIngredients
                    on recipeWithRecipeIngredients.RecipeIngredientId equals recipeIngredient.Id
                join ingredient in _dataContext.Ingredients
                    on recipeIngredient.IngredientId equals ingredient.Id
                where recipe.Approved == true &&
                    recipeIngredient.Quantity <= ingredientQuantity &&
                    ingredient.Name == ingredientName
                select recipe;*/

            var joinQuery = _dataContext
                .RecipeWithRecipeIngredients
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.Recipe)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient.Ingredient)
                .Where(recipeWithRecipeIngredients =>
                    recipeWithRecipeIngredients.RecipeIngredient.Quantity <= ingredientQuantity &&
                    recipeWithRecipeIngredients.RecipeIngredient.Ingredient.Name == ingredientName)
                .Select(recipeWithRecipeIngredients => recipeWithRecipeIngredients.Recipe);

            return await joinQuery.ToListAsync();
        }

        public async Task<List<Recipe>> GetBestMatchRecipesWithInredientAndQuantity(float ingredientQuantity, string ingredientName)
        {
            var quantityLimit = ingredientQuantity / 2;

            /*var joinQuery =
                from recipe in _dataContext.Recipes
                join recipeWithRecipeIngredients in _dataContext.RecipeWithRecipeIngredients
                    on recipe.Id equals recipeWithRecipeIngredients.RecipeId
                join recipeIngredient in _dataContext.RecipeIngredients
                    on recipeWithRecipeIngredients.RecipeIngredientId equals recipeIngredient.Id
                join ingredient in _dataContext.Ingredients
                    on recipeIngredient.IngredientId equals ingredient.Id
                where recipe.Approved == true &&
                    recipeIngredient.Quantity >= quantityLimit &&
                    recipeIngredient.Quantity <= ingredientQuantity &&
                    ingredient.Name == ingredientName
                select recipe;*/

            var joinQuery = _dataContext
                .RecipeWithRecipeIngredients
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.Recipe)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient)
                .Include(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeIngredient.Ingredient)
                .Where(recipeWithRecipeIngredients =>
                    recipeWithRecipeIngredients.RecipeIngredient.Quantity <= ingredientQuantity &&
                    recipeWithRecipeIngredients.RecipeIngredient.Quantity >= quantityLimit &&
                    recipeWithRecipeIngredients.RecipeIngredient.Ingredient.Name == ingredientName)
                .Select(recipeWithRecipeIngredients => recipeWithRecipeIngredients.Recipe);

            return await joinQuery.ToListAsync();
        }

        public async Task<List<int>> GetIngredientIdsOfRecipe(string recipeName, string recipeAuthor)
        {
            /*var joinQuery =
                from recipe in _dataContext.Recipes
                join recipeWithRecipeIngredients in _dataContext.RecipeWithRecipeIngredients
                    on recipe.Id equals recipeWithRecipeIngredients.RecipeId
                join recipeIngredient in _dataContext.RecipeIngredients
                    on recipeWithRecipeIngredients.RecipeIngredientId equals recipeIngredient.Id
                where recipe.Name == recipeName && recipe.Author == recipeAuthor
                select recipeIngredient.IngredientId;*/

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
