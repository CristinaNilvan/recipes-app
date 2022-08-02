﻿using RecipesApp.Domain.Models;

namespace RecipesApp.Domain.CRUD
{
    public class RecipeCRUD : BaseCRUD<Recipe>
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
