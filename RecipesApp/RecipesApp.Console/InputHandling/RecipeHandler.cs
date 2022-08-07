using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.InMemoryRepositories;
using MediatR;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.InMemoryRepositories;

namespace RecipesApp.Console.InputHandling
{
    internal class RecipeHandler
    {
        private static readonly IMediator _mediator = MediatorSetup.GetMediatorForRecipe();

        public static void HandleCreateRecipe()
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

            var ingredientList = InputHandlingUtils.CreateIngredientList().Result;

            _mediator.Send(new CreateRecipe()
            {
                Name = name,
                Author = author,
                Description = description,
                MealType = enumMealType,
                ServingTime = enumServingTime,
                Ingredients = ingredientList
            });
        }

        public static async void HandleReadRecipe()
        {
            System.Console.WriteLine("Please enter the id: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            var recipe = await _mediator.Send(new GetRecipeById()
            {
                RecipeId = id
            });

            System.Console.WriteLine(recipe);
        }

        public static async void HandleUpdateRecipe()
        {
            HandleReadAllRecipes();

            System.Console.WriteLine("Enter the id of the element you want to update: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

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

            var ingredientList = InputHandlingUtils.CreateIngredientList().Result;

            await _mediator.Send(new UpdateRecipe()
            {
                RecipeId = id,
                Name = name,
                Author = author,
                Description = description,
                MealType = enumMealType,
                ServingTime = enumServingTime,
                Ingredients = ingredientList
            });
        }

        public static async void HandleDeleteRecipe()
        {
            HandleReadAllRecipes();

            System.Console.WriteLine("Enter the id of the element you want to delete: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            await _mediator.Send(new DeleteRecipe()
            {
                RecipeId = id
            });
        }

        public static async void HandleReadAllRecipes()
        {
            System.Console.WriteLine("Here are the current recipes: ");
            var recipes = await _mediator.Send(new GetAllRecipes());
            ListPrinter.PrintList(recipes);
        }
    }
}
