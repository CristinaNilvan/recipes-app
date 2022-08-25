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

        public async Task UpdateRecipe(Recipe recipe)
        {
            _dataContext.Recipes.Update(recipe);

            /*var recipeToUpdate = await _dataContext.Recipes.SingleOrDefaultAsync(x => x.Id == recipe.Id);

            recipeToUpdate.Name = recipe.Name;
            recipeToUpdate.Author = recipe.Author;
            recipeToUpdate.Description = recipe.Description;
            recipeToUpdate.MealType = recipe.MealType;
            recipeToUpdate.ServingTime = recipe.ServingTime;
            recipeToUpdate.Servings = recipe.Servings;
            recipeToUpdate.Calories = recipe.Calories;
            recipeToUpdate.Fats = recipe.Fats;
            recipeToUpdate.Carbs = recipe.Carbs;
            recipeToUpdate.Proteins = recipe.Proteins;
            recipeToUpdate.Approved = recipe.Approved;
            recipeToUpdate.RecipeWithRecipeIngredients = recipe.RecipeWithRecipeIngredients;*/
        }

        public async Task UpdateRecipeStatus(Recipe recipe, bool status)
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
                .Select(recipeWithRecipeIngredients => recipeWithRecipeIngredients.Recipe);

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
                .Select(recipeWithRecipeIngredients => recipeWithRecipeIngredients.Recipe);

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
