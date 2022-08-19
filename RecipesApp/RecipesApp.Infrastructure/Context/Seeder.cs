using Bogus;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure.Context
{
    public class Seeder
    {
        public static void SeedData()
        {
            using var context = new DataContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var ingredients = GetPreconfiguredIngredients().ToList();
            var recipes = GetPreconfiguredRecipes().ToList();

            context.Ingredients.AddRange(ingredients);
            context.Recipes.AddRange(recipes);

            context.SaveChanges();
        }


        private static IEnumerable<Ingredient> GetPreconfiguredIngredients()
        {
            var ingredientNames = new List<string>()
            {
                "Ing1",
                "Ing2",
                "Ing3",
                "Ing4",
                "Ing5",
                "Ing6",
                "Ing7",
                "Ing8",
                "Ing9",
                "Ing10",
                "Ing11",
                "Ing12"
            };

            return ingredientNames.Select(ingredientName =>
                new Faker<Ingredient>()
                .RuleFor(ingredient => ingredient.Name, ingredientName)
                .RuleFor(ingredient => ingredient.Category, faker => faker.PickRandom<IngredientCategory>())
                .RuleFor(ingredient => ingredient.Calories, faker => faker.Random.Float(50f, 300f))
                .RuleFor(ingredient => ingredient.Fats, faker => faker.Random.Float(50f, 300f))
                .RuleFor(ingredient => ingredient.Carbs, faker => faker.Random.Float(50f, 300f))
                .RuleFor(ingredient => ingredient.Proteins, faker => faker.Random.Float(50f, 300f))
                .RuleFor(ingredient => ingredient.Approved, faker => faker.Random.Bool())
                .Generate()
                );
        }

        private static IEnumerable<Recipe> GetPreconfiguredRecipes()
        {
            var recipeNames = new List<string>()
            {
                "Rec1",
                "Rec2",
                "Rec3",
                "Rec4",
                "Rec5",
                "Rec6",
                "Rec7",
                "Rec8",
                "Rec9",
                "Rec10",
                "Rec11",
                "Rec12"
            };

            return recipeNames.Select(recipeName =>
                new Faker<Recipe>()
                .RuleFor(recipe => recipe.Name, recipeName)
                .RuleFor(recipe => recipe.Author, faker => faker.Person.FullName)
                .RuleFor(recipe => recipe.Description, faker => faker.Lorem.Paragraph())
                .RuleFor(recipe => recipe.MealType, faker => faker.PickRandom<MealType>())
                .RuleFor(recipe => recipe.ServingTime, faker => faker.PickRandom<ServingTime>())
                .RuleFor(recipe => recipe.Servings, faker => faker.Random.Float(1f, 10f))
                .RuleFor(recipe => recipe.Calories, faker => faker.Random.Float(300f, 800f))
                .RuleFor(recipe => recipe.Fats, faker => faker.Random.Float(300f, 800f))
                .RuleFor(recipe => recipe.Carbs, faker => faker.Random.Float(300f, 800f))
                .RuleFor(recipe => recipe.Proteins, faker => faker.Random.Float(300f, 800f))
                .RuleFor(recipe => recipe.Approved, faker => faker.Random.Bool())
                .Generate()
                );
        }

        /*public static IEnumerable<MealPlan> GetPreconfiguredMealPlans()
        {
            var recipes = GetPreconfiguredRecipes();

            return new Faker<MealPlan>()
                .RuleFor(mealPlan => mealPlan.Breakfast, faker => faker.PickRandom(recipes))
                .Generate();
        }*/
    }
}

