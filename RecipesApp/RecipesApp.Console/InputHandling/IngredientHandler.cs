using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.InMemoryRepositories;

namespace RecipesApp.Console.InputHandling
{
    internal class IngredientHandler
    {
        private static InMemoryIngredientRepository _repository = new InMemoryIngredientRepository(); //?
        private static IMediator _mediator = MediatorSetup.GetMediatorForIngredient();

        public static InMemoryIngredientRepository IngredientRepository => _repository; //?

        public static async void HandleCreateIngredient()
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

            await _mediator.Send(new CreateIngredient()
            {
                Name = name,
                Category = enumCategory,
                Calories = calories,
                Fats = fats,    
                Carbs = carbs,
                Proteins = proteins
            });
        }

        public static async void HandleReadIngredient()
        {
            System.Console.WriteLine("Please enter the id: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            var ingredient = await _mediator.Send(new GetIngredientById()
            {
                IngredientId = id
            });

            System.Console.WriteLine(ingredient);
        }

        public static async void HandleUpdateIngredient()
        {
            HandleReadAllIngredients();

            System.Console.WriteLine("Enter the id of the element you want to update: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

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

            await _mediator.Send(new UpdateIngredient()
            {
                IngredientId = id,
                Name = name,
                Category = enumCategory,
                Calories = calories,
                Fats = fats,
                Carbs = carbs,
                Proteins = proteins
            });
        }

        public static async void HandleDeleteIngredient()
        {
            HandleReadAllIngredients();

            System.Console.WriteLine("Enter the id of the element you want to delete: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            await _mediator.Send(new DeleteIngredient()
            {
                IngredientId = id
            });
        }

        public static async void HandleReadAllIngredients()
        {
            System.Console.WriteLine("Here are the current ingredients: ");
            var ingredients = await _mediator.Send(new GetAllIngredients());
            ListPrinter.PrintList(ingredients);
        }
    }
}
