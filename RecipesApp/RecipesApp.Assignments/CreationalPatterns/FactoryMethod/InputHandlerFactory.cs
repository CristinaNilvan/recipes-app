namespace RecipesApp.Assignments.CreationalPatterns.FactoryMethod
{
    public class InputHandlerFactory
    {
        public static IInputHandler GetHandler(string entityName)
        {
            if (entityName == null)
                throw new ArgumentNullException(nameof(entityName));

            if (entityName.ToLower() == "ingredient")
                return new IngredientInputHandler();

            if (entityName.ToLower() == "recipe")
                return new RecipeInputHandler();

            return null;
        }
    }
}
