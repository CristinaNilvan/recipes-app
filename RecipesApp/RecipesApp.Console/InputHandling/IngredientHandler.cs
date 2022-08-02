using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.CRUD;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Console.InputHandling
{
    internal class IngredientHandler
    {
        public static Ingredient HandleCreateIngredient()
        {
            System.Console.WriteLine("Please enter the following data: ");

            System.Console.WriteLine("Id: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

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

            return IngredientCRUD.Create(id, name, enumCategory, calories, fats, carbs, proteins);
        }

        public static void HandleReadIngredients(List<Ingredient> ingredients)
        {
            System.Console.WriteLine("Here are the current ingredients: ");
            ListPrinter.PrintList(ingredients);
        }

        public static void HandleUpdateIngredient(List<Ingredient> ingredients)
        {
            HandleReadIngredients(ingredients);

            System.Console.WriteLine("Enter the number of the element you want to update: ");
            var number = Convert.ToInt32(System.Console.ReadLine());
            var ingredient = HandleCreateIngredient();

            IngredientCRUD.Update(ingredients, ingredients.ElementAt(number - 1), ingredient);
        }

        public static void HandleDeleteIngredient(List<Ingredient> ingredients)
        {
            HandleReadIngredients(ingredients);

            System.Console.WriteLine("Enter the number of the element you want to delete: ");
            var number = Convert.ToInt32(System.Console.ReadLine());

            IngredientCRUD.Delete(ingredients, ingredients.ElementAt(number - 1));
        }
    }
}
