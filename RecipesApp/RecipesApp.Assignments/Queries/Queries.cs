using Microsoft.EntityFrameworkCore;
using RecipesApp.Infrastructure.Context;

namespace RecipesApp.Assignments.Queries
{
    public class Queries
    {
        public static async Task DoQueries()
        {
            await using var context = new DataContext();

            Console.WriteLine("Paging recipes:");

            var pageSize = 5;
            var query1 = context
                .Recipes
                .OrderBy(x => x.Name)
                .Take(pageSize)
                .ToList();

            ListPrinter.PrintList(query1);


            Console.WriteLine("The maximum number of calories of an ingredient:");

            var query2 = context
                .Ingredients
                .Max(x => x.Calories);

            Console.WriteLine(query2);


            Console.WriteLine("Ingredients grouped by type:");

            var query3 = context
                .Ingredients
                .GroupBy(x => x.Category)
                .Select(x => new IngredientStatsDto
                {
                    CategoryName = x.Key.ToString(),
                    NumberOfIngredients = x.Count(),
                })
                .ToList();

            ListPrinter.PrintList(query3);


            Console.WriteLine("Ingredient names of recipe ingredients");

            var query4 = context
                .RecipeIngredients
                .Include(x => x.Ingredient)
                .Select(x => x.Ingredient.Name)
                .Distinct()
                .ToList();

            ListPrinter.PrintList(query4);


            Console.WriteLine("Every recipe with number of ingredients:");

            var query5 = context
                .RecipeWithRecipeIngredients
                .GroupBy(x => x.RecipeId)
                .Select(x => new RecipeWithRecipeIngredientStatsDto
                {
                    RecipeId = x.Key,
                    NumberOfIngredients = x.Count(),
                })
                .ToList();

            ListPrinter.PrintList(query5);


            Console.WriteLine("Every meal type category with average number of calories:");

            var query6 = context
                .Recipes
                .GroupBy(x => x.MealType)
                .Select(x => new RecipeMealTypeStatsDto
                {
                    MealType = x.Key.ToString(),
                    AverageCalories = x.Average(y => y.Calories)
                })
                .ToList();

            ListPrinter.PrintList(query6);


            Console.WriteLine("Every recipe having an ingredient less than 300:");

            var query7 = context
                .RecipeWithRecipeIngredients
                .Include(x => x.Recipe)
                .Include(x => x.RecipeIngredient)
                .Where(x => x.RecipeIngredient.Quantity < 300)
                .Select(x => x.Recipe.Name)
                .Distinct()
                .ToList();

            ListPrinter.PrintList(query7);


            Console.WriteLine("Recipe ingredients details:");

            var query8 = context
                .RecipeIngredients
                .Include(x => x.Ingredient)
                .Select(x => new RecipeIngredientDetailsDto
                {
                    Ingredient = x.Ingredient,
                    Quantity = x.Quantity,
                })
                .ToList();

            ListPrinter.PrintList(query8);


            Console.WriteLine("Recipes that have an ingredient with a quantity:");

            var quantity = 300;
            var name = "Ing2";

            var query9 = context
                .RecipeWithRecipeIngredients
                .Include(x => x.Recipe)
                .Include(x => x.RecipeIngredient)
                .Include(x => x.RecipeIngredient.Ingredient)
                .Where(x => x.RecipeIngredient.Quantity < quantity && x.RecipeIngredient.Ingredient.Name == name)
                .Select(x => x.Recipe)
                .ToList();

            ListPrinter.PrintList(query9);


            Console.WriteLine("Ingredient ids of a recipe:");

            var recipeName = "Rec14";
            var author = "Cristina Nilvan";

            var query10 = context
                .RecipeWithRecipeIngredients
                .Include(x => x.Recipe)
                .Include(x => x.RecipeIngredient)
                .Where(x => x.Recipe.Name == recipeName && x.Recipe.Author == author)
                .Select(x => x.RecipeIngredient.IngredientId)
                .ToList();

            ListPrinter.PrintList(query10);
        }
    }
}
