namespace RecipesApp.Console.InputHandling.Handlers
{
    internal class EntitiesHandler
    {
        public static async Task HandleInputFromConsole(int entity, int operation)
        {
            if (entity == 1)
            {
                await DoIngredientOperation(operation);
            }
            else if (entity == 2)
            {
                await DoRecipeOperation(operation);
            }
            else
            {
                return;
            }
        }

        private static async Task DoIngredientOperation(int operation)
        {
            switch (operation)
            {
                case 1:
                    await IngredientHandler.HandleCreateIngredient();
                    break;
                case 2:
                    await IngredientHandler.HandleReadIngredient();
                    break;
                case 3:
                    await IngredientHandler.HandleUpdateIngredient();
                    break;
                case 4:
                    await IngredientHandler.HandleDeleteIngredient();
                    break;
                case 5:
                    await IngredientHandler.HandleReadAllIngredients();
                    break;
                default:
                    System.Console.WriteLine("Invalid number for operation!");
                    break;
            }
        }

        private static async Task DoRecipeOperation(int operation)
        {
            switch (operation)
            {
                case 1:
                    await RecipeHandler.HandleCreateRecipe();
                    break;
                case 2:
                    await RecipeHandler.HandleReadRecipe();
                    break;
                case 3:
                    await RecipeHandler.HandleUpdateRecipe();
                    break;
                case 4:
                    await RecipeHandler.HandleDeleteRecipe();
                    break;
                case 5:
                    await RecipeHandler.HandleReadAllRecipes();
                    break;
                default:
                    System.Console.WriteLine("Invalid number for operation!");
                    break;
            }
        }
    }
}
