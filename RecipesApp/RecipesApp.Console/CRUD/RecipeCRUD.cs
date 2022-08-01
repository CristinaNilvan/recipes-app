using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Models;

namespace RecipesApp.Console.CRUD
{
    internal class RecipeCRUD : BaseCRUD<Recipe>
    {
        public static Recipe Create(int id, string? name, string? author, string? description, RecipeType? type, int calories,
            float fats, float carbs, float proteins, List<Ingredient>? ingredients)
        {
            return new Recipe(id, name, author, description, type, calories, fats, carbs, proteins, ingredients);
        }

        public static Recipe Create(int id, string? name, string? author, string? description, RecipeType? type,
            List<Ingredient>? ingredients)
        {
            return new Recipe(id, name, author, description, type, ingredients);
        }
    }
}
