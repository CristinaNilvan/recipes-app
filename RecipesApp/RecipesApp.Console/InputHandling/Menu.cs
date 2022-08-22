﻿using RecipesApp.Console.InputHandling.Handlers;
using System.Text;

namespace RecipesApp.Console.InputHandling
{
    internal class Menu
    {
        public static void RunApp()
        {
            var appOptions = new StringBuilder();
            appOptions = appOptions.Append("What would you like to do?\n");
            appOptions = appOptions.Append("1 - do CRUD on entities\n");
            appOptions = appOptions.Append("2 - find a meal plan\n");
            appOptions = appOptions.Append("3 - find recipes by ingredients\n");
            appOptions = appOptions.Append("4 - find best match recipes based on your ingredient\n");
            appOptions = appOptions.Append("5 - approve recipes\n");
            appOptions = appOptions.Append("6 - approve ingredients\n");
            appOptions = appOptions.Append("7 - exit\n");

            System.Console.WriteLine("Recipes App");

            while (true)
            {
                System.Console.WriteLine(appOptions.ToString());

                var nextOperation = Convert.ToInt32(System.Console.ReadLine());

                if (nextOperation == 1)
                {
                    DoCRUDOnEntities();
                }
                else if (nextOperation == 2)
                {
                    FindMealPlan();
                }
                else if (nextOperation == 3)
                {
                    FindRecipesByIngredients();
                }
                else if (nextOperation == 4)
                {
                    FindBestMatchRecipesForIngredient();
                }
                else if (nextOperation == 5)
                {
                    ApproveRecipes();
                }
                else if (nextOperation == 6)
                {
                    ApproveIngredients();
                }
                else if (nextOperation == 7)
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Invalid operation number!");
                    break;
                }
            }
        }

        static void DoCRUDOnEntities()
        {
            var entities = "1 - Ingredient; 2 - Recipe";
            var operations = "1 - Create; 2 - Read; 3 - Update; 4 - Delete; 5 - Read all";

            while (true)
            {
                System.Console.WriteLine("Continue to choose an entity? yes - 1, no - 0");
                var continueToEntity = Convert.ToInt32(System.Console.ReadLine());

                if (continueToEntity == 0)
                {
                    break;
                }

                System.Console.WriteLine("Choose an entity: ");
                System.Console.WriteLine(entities);
                var chosenEntity = Convert.ToInt32(System.Console.ReadLine());
                System.Console.WriteLine($"Chosen entity: {chosenEntity}");

                while (true)
                {
                    System.Console.WriteLine("Continue to choose an operation? yes - 1, no - 0");
                    var continueToOperation = Convert.ToInt32(System.Console.ReadLine());

                    if (continueToOperation == 0)
                    {
                        break;
                    }

                    System.Console.WriteLine("Choose an operation: ");
                    System.Console.WriteLine(operations);
                    var chosenOperation = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine($"Chosen operation: {chosenOperation}");

                    EntitiesHandler.HandleInputFromConsole(chosenEntity, chosenOperation);
                }
            }
        }

        static void FindMealPlan()
        {
            while (true)
            {
                System.Console.WriteLine("Continue to find a meal plan? yes - 1, no - 0");
                var continueToPlanner = Convert.ToInt32(System.Console.ReadLine());

                if (continueToPlanner == 0)
                {
                    break;
                }

                MealPlannerHandler.HandleInputFromConsole();
            }
        }

        static void FindRecipesByIngredients()
        {
            while (true)
            {
                System.Console.WriteLine("Continue to find recipes? yes - 1, no - 0");
                var continueToFind = Convert.ToInt32(System.Console.ReadLine());

                if (continueToFind == 0)
                {
                    break;
                }

                RecipeFinderHandler.HandleInputFromConsole();
            }
        }

        static void FindBestMatchRecipesForIngredient()
        {
            while (true)
            {
                System.Console.WriteLine("Continue to find recipes? yes - 1, no - 0");
                var continueToFind = Convert.ToInt32(System.Console.ReadLine());

                if (continueToFind == 0)
                {
                    break;
                }

                RecipeSuggesterHandler.HandleInputFromConsole();
            }
        }

        static void ApproveRecipes()
        {
            while (true)
            {
                System.Console.WriteLine("Continue to approve a recipe? yes - 1, no - 0");
                var continueToFind = Convert.ToInt32(System.Console.ReadLine());

                if (continueToFind == 0)
                {
                    break;
                }

                RecipeApproverHandler.HandleInputFromConsole();
            }
        }

        static void ApproveIngredients()
        {
            while (true)
            {
                System.Console.WriteLine("Continue to approve an ingredient? yes - 1, no - 0");
                var continueToFind = Convert.ToInt32(System.Console.ReadLine());

                if (continueToFind == 0)
                {
                    break;
                }

                IngredientApproverHandler.HandleInputFromConsole();
            }
        }
    }
}