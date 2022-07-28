using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Models;

namespace RecipesApp.Console.BusinessLogic
{
    internal class HandleInput
    {
        private static List<Ingredient> ingredients = new List<Ingredient>();
        private static List<Recipe> recipes = new List<Recipe>();

        public static void HandleInputFromConsole(int entity, int operation)
        {
            if (entity == 1)
            {
                if (operation == 1)
                {
                    var ingredient = HandleInput.HandleCreateIngredient();

                    if (ingredient != null)
                    {
                        System.Console.WriteLine("Ingredient created successfully!");
                        ingredients.Add(ingredient);
                    }
                    else
                        System.Console.WriteLine("Something went wrong!");
                }

                if (operation == 2)
                {

                }
            }
        }

        private static Ingredient HandleCreateIngredient()
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

            return IngredientCRUDOperations.Create(id, name, enumCategory, calories, fats, carbs, proteins);
        }

        private static void HandleUpdateIngredient()
        {

        }
    }
}
