using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application
{
    public interface IRecipeRepository
    {
        void CreateRecipe(Recipe recipe);
        Recipe GetRecipe(int recipeId);
        void UpdateRecipe(int recipeId, Recipe newRecipe);
        void DeleteRecipe(int recipeId);
        void AddIngredientToRecipe(int recipeId, Ingredient ingredient);
        void DeleteIngredientFromRecipe(int recipeId, int ingredientId);
        IEnumerable<Recipe> GetRecipes();
    }
}
