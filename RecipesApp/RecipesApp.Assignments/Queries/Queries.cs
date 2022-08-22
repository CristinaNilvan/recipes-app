using RecipesApp.Infrastructure.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RecipesApp.Assignments.Queries
{
    public class Queries
    {
        public static async Task DoQueries()
        {
            await using var context = new DataContext();

            /*Console.WriteLine("Paging recipes:");

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

            Console.WriteLine(query2);*/


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
        }
    }
}
