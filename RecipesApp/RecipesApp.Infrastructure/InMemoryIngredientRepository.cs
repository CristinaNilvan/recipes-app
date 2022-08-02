using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Application;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure
{
    internal class InMemoryIngredientRepository : IIngredientRepository
    {
        private List<Ingredient> _ingredients = new List<Ingredient>(PopulateLists.PopulateIngredients());

        public void CreateIngredient(Ingredient ingredient)
        {
            ingredient.Id = _ingredients.Count + 1;
            _ingredients.Add(ingredient);
        }

        public void DeleteIngredient(int ingredientId)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            _ingredients.Remove(ingredient);
        }

        public Ingredient GetIngredient(int ingredientId)
        {
            return _ingredients.FirstOrDefault(x => x.Id == ingredientId);
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            return _ingredients;
        }

        public void UpdateIngredient(int ingredientId, Ingredient newIngredient)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            var index = _ingredients.IndexOf(ingredient);
            _ingredients[index] = newIngredient;
        }
    }
}
