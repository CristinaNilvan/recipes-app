using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Console.InputHandling
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
            var calories = Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("Fats: ");
            var fats = float.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Carbs: ");
            var carbs = float.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Proteins: ");
            var proteins = float.Parse(System.Console.ReadLine());

            return new Ingredient(name, enumCategory, calories, fats, carbs, proteins);
        }

        public static async Task<List<Ingredient>> CreateIngredientList()
        {
            var mediator = MediatorSetup.GetMediator();
            var recipeIngredients = new List<Ingredient>();

            System.Console.WriteLine("For the ingredients you can: ");

            while (true)
            {
                System.Console.WriteLine("1 - add from current ingredients");
                System.Console.WriteLine("2 - create new ingredient");
                var choice = Convert.ToInt32(System.Console.ReadLine());

                if (choice == 1)
                {
                    IngredientHandler.HandleReadAllIngredients();

                    System.Console.WriteLine("Enter the id of the element you want to add: ");
                    var id = Convert.ToInt32(System.Console.ReadLine());

                    var element = await mediator.Send(new GetIngredientById()
                    {
                        IngredientId = id
                    });

                    recipeIngredients.Add(element);
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

                    var ingredientFromRepository = await mediator.Send(new GetIngredientByName() 
                    {
                        IngredientName = ingredientFromInput.Name
                    });

                    recipeIngredients.Add(ingredientFromRepository);
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
    }
}
