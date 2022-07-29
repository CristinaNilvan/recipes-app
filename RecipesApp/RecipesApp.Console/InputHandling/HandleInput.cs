﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Console.InputHandling
{
    internal class HandleInput
    {
        private static List<Ingredient> ingredients = new List<Ingredient>();
        private static List<Recipe> recipes = new List<Recipe>();

        public static void HandleInputFromConsole(int entity, int operation)
        {
            if (entity == 1)
            {
                DoIngredientOperation(operation);
            }
            else if (entity == 2)
            {

            }
        }

        private static void DoIngredientOperation(int operation)
        {
            if (operation == 1)
            {
                var ingredient = HandleIngredientInput.HandleCreateIngredient();

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
                HandleIngredientInput.HandleReadIngredients(ingredients);
            }

            if (operation == 3)
            {
                HandleIngredientInput.HandleUpdateIngredient(ingredients);

                System.Console.WriteLine("The list after the update: ");
                ListPrinter.PrintList(ingredients);
            }

            if (operation == 4)
            {
                HandleIngredientInput.HandleDeleteIngredient(ingredients);

                System.Console.WriteLine("The list after the deletion: ");
                ListPrinter.PrintList(ingredients);
            }
        }
    }
}