/*using RecipesApp.Infrastructure.Context;

await using var context = new DataContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

Seeder.SeedData();*/

/*using RecipesApp.Console.TestFunctionalities;

TestFunctionalitiesWithDb.TestMediators();*/

/*using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.Context;

await using var context = new DataContext();

var query = context
    .Recipes
    .Join(context.RecipeWithRecipeIngredients,
    a => a.Id,
    b => b.RecipeId,
    (a, b) => new Recipe(a.Id, a.Name, a.Author, a.Description, a.MealType, a.ServingTime, a.Servings)).ToList();

foreach (var item in query)
{
    Console.WriteLine(item);
}*/

/*using RecipesApp.Console.InputHandling.Utils;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.Context;

var ingList = new List<Ingredient>()
{
    new Ingredient
    {
        Id = 2,
    },
    new Ingredient
    {
        Id = 8,
    }
};

var intIngList = GetIngredientIds(ingList);
Console.WriteLine("ing ids: ");
ListPrinter.PrintList(intIngList);

var toCompare = new List<int>() { 2, 8 };

var matched = CheckIfRecipeContainsAllIngredients(intIngList, toCompare);

Console.WriteLine(matched);

static List<int> GetIngredientIds(List<Ingredient> ingredients)
            => ingredients.Select(x => x.Id).ToList();

static bool CheckIfRecipeContainsAllIngredients(List<int> recipeIngredientList,
    List<int> givenIngredientList)
    => givenIngredientList.All(x => recipeIngredientList.Any(y => x == y));
*/

using RecipesApp.Console.InputHandling;

await Menu.RunApp();

/*using RecipesApp.Assignments.Queries;

await Queries.DoQueries();*/