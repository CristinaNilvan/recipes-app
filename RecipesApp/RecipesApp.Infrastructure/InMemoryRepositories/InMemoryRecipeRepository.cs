﻿using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure.InMemoryRepositories
{
    public class InMemoryRecipeRepository : IRecipeRepository
    {
        private List<Recipe> _recipes = new List<Recipe>(PopulateLists.PopulateRecipes());

        public void AddIngredientToRecipe(int recipeId, Ingredient ingredient)
        {
            var recipe = _recipes.FirstOrDefault(x => x.Id == recipeId);
            recipe.AddIngredient(ingredient);
        }

        public void CreateRecipe(Recipe recipe)
        {
            recipe.Id = _recipes.Count > 0 ? _recipes.ElementAt(_recipes.Count - 1).Id + 1 : 1;
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

        public List<Recipe> GetApprovedRecipes()
        {
            return _recipes.Where(x => x.Approved == true).ToList();
        }

        public List<Recipe> GetUnapprovedRecipes()
        {
            return _recipes.Where(x => x.Approved == false).ToList();
        }

        public List<Recipe> GetRecipesByIngredients(List<Ingredient> ingredients)
        {
            var approvedRecipes = GetApprovedRecipes();
            var filteredRecipes = new List<Recipe>();

            foreach (var recipe in approvedRecipes)
            {
                var containsAll = CheckIfRecipeContainsAllIngredients(recipe.Ingredients, ingredients);

                if (containsAll)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes;
        }

        public void UpdateRecipe(int recipeId, Recipe newRecipe)
        {
            var recipe = _recipes.FirstOrDefault(x => x.Id == recipeId);
            var index = _recipes.IndexOf(recipe);
            newRecipe.Id = recipeId;
            _recipes[index] = newRecipe;
        }

        public void UpdateRecipeStatus(int recipeId, bool status)
        {
            var recipe = _recipes.FirstOrDefault(x => x.Id == recipeId);
            recipe.Approved = status;
        }

        private bool CheckIfRecipeContainsAllIngredients(List<Ingredient> recipeIngredientList, List<Ingredient> givenIngredientList)
        {
            return givenIngredientList.All(x => recipeIngredientList.Any(y => x.Id == y.Id));
        }
    }
}
