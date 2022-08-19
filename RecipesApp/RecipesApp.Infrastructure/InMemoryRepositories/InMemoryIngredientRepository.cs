using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure.InMemoryRepositories
{
    public class InMemoryIngredientRepository : IIngredientRepository
    {
        private List<Ingredient> _ingredients = new List<Ingredient>(PopulateLists.PopulateIngredients());

        public async Task<Ingredient> CreateIngredient(Ingredient ingredient)
        {
            ingredient.Id = _ingredients.Count > 0 ? _ingredients.ElementAt(_ingredients.Count - 1).Id + 1 : 1;
            _ingredients.Add(ingredient);

            return ingredient;
        }

        public async Task<Ingredient> DeleteIngredient(int ingredientId)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            _ingredients.Remove(ingredient);

            return ingredient;
        }

        public async Task<Ingredient> GetIngredientById(int ingredientId)
        {
            return _ingredients.FirstOrDefault(x => x.Id == ingredientId);
        }

        public async Task<Ingredient> GetIngredientByName(string ingredientName)
        {
            return _ingredients.FirstOrDefault(x => x.Name == ingredientName);
        }

        public async Task<List<Ingredient>> GetAllIngredients()
        {
            return _ingredients;
        }

        public async Task<List<Ingredient>> GetIngredientsByApprovedStatus(bool isApproved)
        {
            return _ingredients.Where(x => x.Approved == isApproved).ToList();
        }

        public async Task<Ingredient> UpdateIngredient(Ingredient newIngredient)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == newIngredient.Id);
            var index = _ingredients.IndexOf(ingredient);
            ingredient.Id = newIngredient.Id;
            _ingredients[index] = newIngredient;

            return newIngredient;
        }

        public async Task<Ingredient> UpdateIngredientStatus(int ingredientId, bool status)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            ingredient.Approved = status;

            return ingredient;
        }
    }
}
