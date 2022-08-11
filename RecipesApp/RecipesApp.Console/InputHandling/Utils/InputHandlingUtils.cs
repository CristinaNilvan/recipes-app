using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Application.Ingredients.Queries;
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

        public static Recipe CreateRecipeFromInput()
        {
            System.Console.WriteLine("Please enter the following data: ");

            System.Console.WriteLine("Name: ");
            var name = System.Console.ReadLine();

            System.Console.WriteLine("Author: ");
            var author = System.Console.ReadLine();

            System.Console.WriteLine("Decription: ");
            var description = System.Console.ReadLine();

            System.Console.WriteLine("Meal Type [Normal, Vegetarian, Vegan]: ");
            var mealType = System.Console.ReadLine();
            var enumMealType = (MealType)Enum.Parse(typeof(MealType), mealType, true);

            System.Console.WriteLine("Serving Time [Breakfast, Lunch, Dinner]: ");
            var servingTime = System.Console.ReadLine();
            var enumServingTime = (ServingTime)Enum.Parse(typeof(ServingTime), servingTime, true);

            System.Console.WriteLine("Number of servings: ");
            var servings = float.Parse(System.Console.ReadLine());

            var ingredientList = CreateIngredientListForRecipe().Result;

            return new Recipe(name, author, description, enumMealType, enumServingTime, servings, ingredientList);
        }

        public static async Task<List<Ingredient>> CreateIngredientListForRecipe()
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

                    System.Console.WriteLine("Enter the quantity of the ingredient: ");
                    var quantity = float.Parse(System.Console.ReadLine());

                    var element = await mediator.Send(new GetIngredientById()
                    {
                        IngredientId = id
                    });

                    element.Quantity = quantity;

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

                    System.Console.WriteLine("Enter the quantity of the ingredient: ");
                    var quantity = float.Parse(System.Console.ReadLine());

                    var ingredientFromRepository = await mediator.Send(new GetIngredientByName()
                    {
                        IngredientName = ingredientFromInput.Name
                    });

                    ingredientFromRepository.Quantity = quantity;  

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

        public static async Task<List<Ingredient>> CreateIngredientListForRecipeFinder()
        {
            var mediator = MediatorSetup.GetMediator();
            var ingredients = new List<Ingredient>();

            System.Console.WriteLine("Choose the ingredients you have: ");

            while (true)
            {
                IngredientHandler.HandleReadAllIngredients();

                System.Console.WriteLine("Enter the id of the element you want to add: ");
                var id = Convert.ToInt32(System.Console.ReadLine());

                var element = await mediator.Send(new GetIngredientById()
                {
                    IngredientId = id
                });

                ingredients.Add(element);

                System.Console.WriteLine("What do you want to do next? 1 - continue to add ingredients; 0 - exit");
                var nextChoice = Convert.ToInt32(System.Console.ReadLine());

                if (nextChoice == 0)
                {
                    break;
                }
            }

            return ingredients;
        }
    }
}
