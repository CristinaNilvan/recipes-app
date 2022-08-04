using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure.InMemoryRepositories
{
    public class InMemoryRecipeRepository : IRecipeRepository
    {
        private List<Recipe> _recipes = new List<Recipe>(PopulateLists.PopulateRecipes());

        public List<Recipe> Recipes => _recipes;

        public void AddIngredientToRecipe(int recipeId, Ingredient ingredient)
        {
            var recipe = _recipes.FirstOrDefault(x => x.Id == recipeId);
            recipe.AddIngredient(ingredient);
        }

        public void CreateRecipe(Recipe recipe)
        {
            recipe.Id = _recipes.ElementAt(_recipes.Count - 1).Id + 1;
            _recipes.Add(recipe);
        }

        public void DeleteIngredientFromRecipe(int recipeId, int ingredientId)
        {
            var recipe = _recipes.FirstOrDefault(x => x.Id == recipeId);
            var ingredientToDelete = recipe.Ingredients.FirstOrDefault(x => x.Id == ingredientId);
            recipe.RemoveIngredient(ingredientToDelete);
        }

        public void DeleteRecipe(int recipeId)
        {
            var recipe = _recipes.FirstOrDefault(x => x.Id == recipeId);
            _recipes.Remove(recipe);
        }

        public Recipe GetRecipeById(int recipeId)
        {
            return _recipes.FirstOrDefault(x => x.Id == recipeId);
        }

        public Recipe GetRecipeByName(string recipeName)
        {
            return _recipes.FirstOrDefault(x => x.Name == recipeName);
        }

        public List<Recipe> GetAllRecipes()
        {
            return _recipes;
        }

        public void UpdateRecipe(int recipeId, Recipe newRecipe)
        {
            var recipe = _recipes.FirstOrDefault(x => x.Id == recipeId);
            var index = _recipes.IndexOf(recipe);
            newRecipe.Id = recipeId;
            _recipes[index] = newRecipe;
        }
    }
}
