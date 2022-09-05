using Bogus;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.Context;

namespace RecipesApp.IntegrationTests.Utils
{
    internal class InMemoryDbSeeder
    {
        public static void SeedData(DataContext context)
        {
            var ingredients = GetPreconfiguredIngredients();

            context.Ingredients.AddRange(ingredients);
            context.SaveChanges();
        }

        private static List<Ingredient> GetPreconfiguredIngredients()
        {
            var ingredient01 = new Ingredient
            {
                Id = 1,
                Name = "Ing1",
                Category = IngredientCategory.Meat,
                Calories = 50,
                Fats = 50,
                Carbs = 50,
                Proteins = 50,
                Approved = true,
                IngredientImage = null
            };

            var ingredient02 = new Ingredient
            {
                Id = 2,
                Name = "Ing2",
                Category = IngredientCategory.Dairy,
                Calories = 50,
                Fats = 50,
                Carbs = 50,
                Proteins = 50,
                Approved = true,
                IngredientImage = null
            };

            var ingredient03 = new Ingredient
            {
                Id = 3,
                Name = "Ing3",
                Category = IngredientCategory.Vegetable,
                Calories = 50,
                Fats = 50,
                Carbs = 50,
                Proteins = 50,
                Approved = true,
                IngredientImage = null
            };

            var ingredient04 = new Ingredient
            {
                Id = 4,
                Name = "Ing4",
                Category = IngredientCategory.Fruit,
                Calories = 50,
                Fats = 50,
                Carbs = 50,
                Proteins = 50,
                Approved = true,
                IngredientImage = null
            };

            var ingredient05 = new Ingredient
            {
                Id = 5,
                Name = "Ing5",
                Category = IngredientCategory.Others,
                Calories = 50,
                Fats = 50,
                Carbs = 50,
                Proteins = 50,
                Approved = true,
                IngredientImage = null
            };

            var ingredients = new List<Ingredient>()
            {
                ingredient01,
                ingredient02,
                ingredient03,
                ingredient04,
                ingredient05
            };

            return ingredients;
        }
    }
}
