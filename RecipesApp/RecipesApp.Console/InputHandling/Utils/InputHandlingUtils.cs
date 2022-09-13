using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Application.RecipeIngredients.Commands;
using RecipesApp.Console.InputHandling.Handlers;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Console.InputHandling.Utils
{
    internal class InputHandlingUtils
    {
        public static Ingredient CreateIngredientFromInput()
        {
            System.Console.WriteLine("Please enter the following data: ");

            System.Console.WriteLine("Name: ");
            var name = System.Console.ReadLine();

            System.Console.WriteLine("Category [Meat, Dairy, Fruit, Vegetable, Herbs, Others]: ");
            var category = System.Console.ReadLine();
            var enumCategory = (IngredientCategory)Enum.Parse(typeof(IngredientCategory), category, true);

            System.Console.WriteLine("Calories: ");
            var calories = float.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Fats: ");
            var fats = float.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Carbs: ");
            var carbs = float.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Proteins: ");
            var proteins = float.Parse(System.Console.ReadLine());

            return new Ingredient(name, enumCategory, calories, fats, carbs, proteins);
        }

        public static async Task<List<RecipeIngredient>> CreateIngredientListForRecipe()
        {
            var mediator = MediatorSetup.GetMediator();
            var recipeIngredients = new List<RecipeIngredient>();

            System.Console.WriteLine("For the ingredients you can: ");

            while (true)
            {
                System.Console.WriteLine("1 - add from current ingredients");
                System.Console.WriteLine("2 - create new ingredient");
                var choice = Convert.ToInt32(System.Console.ReadLine());

                if (choice == 1)
                {
                    await IngredientHandler.HandleReadAllIngredients();

                    System.Console.WriteLine("Enter the id of the ingredient you want to add: ");
                    var ingredientId = Convert.ToInt32(System.Console.ReadLine());

                    System.Console.WriteLine("Here are the recipe ingredients using this ingredient: ");

                    var recipeIngredientsByIngredientId = await mediator.Send(new GetIngredientById()
                    {
                        IngredientId = ingredientId
                    });

                    ListPrinter.PrintList(recipeIngredientsByIngredientId.RecipeIngredients);

                    System.Console.WriteLine("1 - add from current recipe ingredients");
                    System.Console.WriteLine("2 - create new recipe ingredient");

                    var recipeIngredientChoice = Convert.ToInt32(System.Console.ReadLine());

                    if (recipeIngredientChoice == 1)
                    {
                        System.Console.WriteLine("Enter the id of the recipe ingredient you want to add: ");
                        var recipeIngredientId = Convert.ToInt32(System.Console.ReadLine());

                        var recipeIngredient = await mediator.Send(new Application.RecipeIngredients.Queries.GetRecipeIngredientById()
                        {
                            RecipeIngredientId = recipeIngredientId
                        });

                        recipeIngredients.Add(recipeIngredient);
                    }
                    else if (recipeIngredientChoice == 2)
                    {
                        System.Console.WriteLine("Enter the quantity of the ingredient: ");
                        var quantity = float.Parse(System.Console.ReadLine());

                        var recipeIngredient = await mediator.Send(new CreateRecipeIngredient()
                        {
                            Quantity = quantity,
                            IngredientId = ingredientId
                        });

                        recipeIngredients.Add(recipeIngredient);
                    }
                }
                else if (choice == 2)
                {
                    var ingredientFromInput = CreateIngredientFromInput();

                    await mediator.Send(new CreateIngredient()
                    {
                        Name = ingredientFromInput.Name,
                        Category = ingredientFromInput.Category,
                        Calories = ingredientFromInput.Calories,
                        Fats = ingredientFromInput.Fats,
                        Carbs = ingredientFromInput.Carbs,
                        Proteins = ingredientFromInput.Proteins
                    });

                    var ingredientFromDb = await mediator.Send(new GetIngredientByName()
                    {
                        IngredientName = ingredientFromInput.Name
                    });

                    System.Console.WriteLine("Enter the quantity of the ingredient: ");
                    var quantity = float.Parse(System.Console.ReadLine());

                    var recipeIngredient = await mediator.Send(new CreateRecipeIngredient()
                    {
                        Quantity = quantity,
                        IngredientId = ingredientFromDb.Id
                    });

                    recipeIngredients.Add(recipeIngredient);
                }

                System.Console.WriteLine("What do you want to do next? 1 - continue to add ingredients to recipe; 0 - exit");
                var nextChoice = Convert.ToInt32(System.Console.ReadLine());

                if (nextChoice == 0)
                {
                    break;
                }
            }

            return recipeIngredients;
        }

        public static async Task<List<Ingredient>> CreateIngredientListForRecipeFinder()
        {
            var mediator = MediatorSetup.GetMediator();
            var ingredients = new List<Ingredient>();

            System.Console.WriteLine("Choose the ingredients you have: ");

            while (true)
            {
                await IngredientHandler.HandleReadAllIngredients();

                System.Console.WriteLine("Enter the id of the ingredient you want to add: ");
                var id = Convert.ToInt32(System.Console.ReadLine());

                var ingredient = await mediator.Send(new GetIngredientById()
                {
                    IngredientId = id
                });

                ingredients.Add(ingredient);

                System.Console.WriteLine("What do you want to do next? 1 - continue to add ingredients; 0 - exit");
                var nextChoice = Convert.ToInt32(System.Console.ReadLine());

                if (nextChoice == 0)
                {
                    break;
                }
            }

            return ingredients;
        }

        public static List<int> GetIngredientIds(List<Ingredient> ingredients)
            => ingredients.Select(x => x.Id).ToList();
    }
}
