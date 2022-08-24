/*using RecipesApp.Infrastructure.Context;

await using var context = new DataContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

Seeder.SeedData();*/

/*using RecipesApp.Console.TestFunctionalities;

await TestFunctionalitiesWithDb.TestMediators();*/

/*using RecipesApp.Assignments.Queries;

await Queries.DoQueries();*/


using RecipesApp.Console.InputHandling;

await Menu.RunApp();