using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure.InMemoryRepositories
{
    public class InMemoryIngredientRepository : IIngredientRepository
    {
        private List<Ingredient> _ingredients = new List<Ingredient>(PopulateLists.PopulateIngredients());

        public void CreateIngredient(Ingredient ingredient)
        {
            ingredient.Id = _ingredients.Count > 0 ? _ingredients.ElementAt(_ingredients.Count - 1).Id + 1 : 1;
            _ingredients.Add(ingredient);
        }

        public void DeleteIngredient(int ingredientId)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            _ingredients.Remove(ingredient);
        }

        public Ingredient GetIngredientById(int ingredientId)
        {
            return _ingredients.FirstOrDefault(x => x.Id == ingredientId);
        }

        public Ingredient GetIngredientByName(string ingredientName)
        {
            return _ingredients.FirstOrDefault(x => x.Name == ingredientName);
        }

        public List<Ingredient> GetAllIngredients()
        {
            return _ingredients;
        }

        public List<Ingredient> GetIngredientsByApprovedStatus(bool isApproved)
        {
            return _ingredients.Where(x => x.Approved == isApproved).ToList();
        }

        public void UpdateIngredient(int ingredientId, Ingredient newIngredient)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            var index = _ingredients.IndexOf(ingredient);
            newIngredient.Id = ingredientId;
            _ingredients[index] = newIngredient;
        }

        public void UpdateIngredientStatus(int ingredientId, bool status)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            ingredient.Approved = status;
        }
    }
}
