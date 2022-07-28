using RecipesApp.Domain.Models;

namespace RecipesApp.Console.BusinessLogic
{
    internal class IngredientCRUDOperations : BaseCRUDOperations<Ingredient>
    {
        public static Ingredient Create(int id, string? name, IngredientCategory category, int calories, float fats,
            float carbs, float proteins)
        {
            return new Ingredient(id, name, category, calories, fats, carbs, proteins);
        }
    }
}
