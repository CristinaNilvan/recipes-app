using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.InMemoryRepositories;

namespace RecipesApp.Console.InputHandling
{
    internal class IngredientHandler
    {
        private static InMemoryIngredientRepository _repository = new InMemoryIngredientRepository();

        public static InMemoryIngredientRepository IngredientRepository => _repository;

        public static void HandleCreateIngredient()
        {
            _repository.CreateIngredient(CreateIngredientFromInput());
        }

        public static void HandleReadIngredient()
        {
            System.Console.WriteLine("Please enter the id: ");
            var id = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine(_repository.GetIngredient(id));
        }

        public static void HandleUpdateIngredient()
        {
            HandleReadIngredients();

            System.Console.WriteLine("Enter the id of the element you want to update: ");
            var id = Convert.ToInt32(System.Console.ReadLine());
            var ingredient = CreateIngredientFromInput();

            _repository.UpdateIngredient(id, ingredient);
        }

        public static void HandleDeleteIngredient()
        {
            HandleReadIngredients();

            System.Console.WriteLine("Enter the id of the element you want to delete: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            _repository.DeleteIngredient(id);
        }

        public static void HandleReadIngredients()
        {
            System.Console.WriteLine("Here are the current ingredients: ");
            ListPrinter.PrintList(_repository.Ingredients);
        }

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
    }
}
