namespace RecipesApp.Console.InputHandling
{
    internal class EntitiesHandler
    {
        public static void HandleInputFromConsole(int entity, int operation)
        {
            if (entity == 1)
            {
                DoIngredientOperation(operation);
            }
            else if (entity == 2)
            {
                DoRecipeOperation(operation);
            } 
            else
            {
                return;
            }
        }

        private static void DoIngredientOperation(int operation)
        {
            switch (operation)
            {
                case 1:
                    IngredientHandler.HandleCreateIngredient();
                    break;
                case 2:
                    IngredientHandler.HandleReadIngredient();
                    break;
                case 3:
                    IngredientHandler.HandleUpdateIngredient();
                    break;
                case 4:
                    IngredientHandler.HandleDeleteIngredient();
                    break;
                case 5:
                    IngredientHandler.HandleReadAllIngredients();
                    break;
                default:
                    System.Console.WriteLine("Invalid number for operation!");
                    break;
            }
        }

        private static void DoRecipeOperation(int operation)
        {
            switch (operation)
            {
                case 1:
                    RecipeHandler.HandleCreateRecipe();
                    break;
                case 2:
                    RecipeHandler.HandleReadRecipe();
                    break;
                case 3:
                    RecipeHandler.HandleUpdateRecipe();
                    break;
                case 4:
                    RecipeHandler.HandleDeleteRecipe();
                    break;
                case 5:
                    RecipeHandler.HandleReadAllRecipes();
                    break;
                default:
                    System.Console.WriteLine("Invalid number for operation!");
                    break;
            }
        }
    }
}
