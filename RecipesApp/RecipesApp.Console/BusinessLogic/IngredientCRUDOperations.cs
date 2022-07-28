using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Models;

namespace RecipesApp.Console.BusinessLogic
{
    internal class IngredientCRUDOperations
    {
        public static Ingredient CreateIngredient(int id, string? name, IngredientCategory category, int calories, float fats,
            float carbs, float proteins)
        {
            return new Ingredient(id, name, category, calories, fats, carbs, proteins);
        }
    }
}
