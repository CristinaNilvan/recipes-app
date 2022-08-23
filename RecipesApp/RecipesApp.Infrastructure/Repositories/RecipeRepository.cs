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

        //to update
        public async Task<Recipe> UpdateRecipe(Recipe newRecipe, List<RecipeIngredient> recipeIngredients)
        {
            _dataContext.Recipes.Update(newRecipe);
            await _dataContext.SaveChangesAsync();

            var recipeFromDb = await GetRecipeByName(newRecipe.Name);

            var oldRecipeIngredients = _dataContext
                .RecipeWithRecipeIngredients
                .Where(x => x.RecipeId == recipeFromDb.Id)
                .ToList();

            foreach (var item in oldRecipeIngredients)
            {
                var auxItem = _dataContext.RecipeWithRecipeIngredients.Find(item.Id);
                _dataContext.RecipeWithRecipeIngredients.Remove(auxItem);
                await _dataContext.SaveChangesAsync();
            }

            await _dataContext.SaveChangesAsync();

            foreach (var recipeIngredient in recipeIngredients)
            {
                var auxRecipeIng = _dataContext.RecipeIngredients.Find(recipeIngredient.Id);

                var recipeWithRecipeIngredient = new RecipeWithRecipeIngredient
                {
                    RecipeId = recipeFromDb.Id,
                    Recipe = newRecipe,
                    RecipeIngredientId = auxRecipeIng.Id,
                    RecipeIngredient = auxRecipeIng
                };

                _dataContext.RecipeWithRecipeIngredients.Add(recipeWithRecipeIngredient);
                await _dataContext.SaveChangesAsync();
            }

            return newRecipe;
        }

        public async Task<Recipe> UpdateRecipeStatus(int recipeId, bool status)
        {
            var recipe = await _dataContext.Recipes.SingleOrDefaultAsync(x => x.Id == recipeId);

            recipe.Approved = status;
            await _dataContext.SaveChangesAsync();

            return recipe;
        }

        public async Task<List<Recipe>> GetRecipesWithInredientAndQuantity(float ingredientQuantity, string ingredientName)
        {
            var joinQuery =
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
                select recipe;

            return await joinQuery.ToListAsync();
        }

        public async Task<List<Recipe>> GetBestMatchRecipesWithInredientAndQuantity(float ingredientQuantity, string ingredientName)
        {
            var joinQuery =
                from recipe in _dataContext.Recipes
                join recipeWithRecipeIngredients in _dataContext.RecipeWithRecipeIngredients
                    on recipe.Id equals recipeWithRecipeIngredients.RecipeId
                join recipeIngredient in _dataContext.RecipeIngredients
                    on recipeWithRecipeIngredients.RecipeIngredientId equals recipeIngredient.Id
                join ingredient in _dataContext.Ingredients
                    on recipeIngredient.IngredientId equals ingredient.Id
                where recipe.Approved == true &&
                    recipeIngredient.Quantity >= ingredientQuantity / 2 &&
                    ingredient.Name == ingredientName
                select recipe;

            return await joinQuery.ToListAsync();
        }

        public async Task<List<int>> GetIngredientIdsOfRecipe(string recipeName, string recipeAuthor)
        {
            var joinQuery =
                from recipe in _dataContext.Recipes
                join recipeWithRecipeIngredients in _dataContext.RecipeWithRecipeIngredients
                    on recipe.Id equals recipeWithRecipeIngredients.RecipeId
                join recipeIngredient in _dataContext.RecipeIngredients
                    on recipeWithRecipeIngredients.RecipeIngredientId equals recipeIngredient.Id
                where recipe.Name == recipeName && recipe.Author == recipeAuthor
                select recipeIngredient.IngredientId;

            return await joinQuery.ToListAsync();
        }
    }
}
