using RecipesApp.Console.InputHandling.Handlers;
using System.Text;

var appOptions = new StringBuilder();
appOptions = appOptions.Append("What would you like to do?\n");
appOptions = appOptions.Append("1 - do CRUD on entities\n");
appOptions = appOptions.Append("2 - find a meal plan\n");
appOptions = appOptions.Append("3 - find a recipe by ingredients\n");
appOptions = appOptions.Append("4 - approve recipes\n");
appOptions = appOptions.Append("5 - exit\n");

Console.WriteLine("Recipes App");

while (true)
{
    Console.WriteLine(appOptions.ToString());

    var nextOperation = Convert.ToInt32(Console.ReadLine());
    switch (nextOperation)
    {
        case 1:
            DoCRUDOnEntities();
            break;
        case 2:
            FindMealPlan();
            break;
        case 3:
            FindRecipeByIngredients();
            break;
        case 4:
            ApproveRecipes();
            break;
        case 5:
            break;
        default:
            Console.WriteLine("Invalid number for operation!");
            break;
    }
}


static void DoCRUDOnEntities()
{
    var entities = "1 - Ingredient; 2 - Recipe";
    var operations = "1 - Create; 2 - Read; 3 - Update; 4 - Delete; 5 - Read all";

    while (true)
    {
        Console.WriteLine("Continue to choose an entity? yes - 1, no - 0");
        var continueToEntity = Convert.ToInt32(Console.ReadLine());

        if (continueToEntity == 0)
        {
            break;
        }

        Console.WriteLine("Choose an entity: ");
        Console.WriteLine(entities);
        var chosenEntity = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Chosen entity: {chosenEntity}");

        while (true)
        {
            Console.WriteLine("Continue to choose an operation? yes - 1, no - 0");
            var continueToOperation = Convert.ToInt32(Console.ReadLine());

            if (continueToOperation == 0)
            {
                break;
            }

            Console.WriteLine("Choose an operation: ");
            Console.WriteLine(operations);
            var chosenOperation = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Chosen operation: {chosenOperation}");

            EntitiesHandler.HandleInputFromConsole(chosenEntity, chosenOperation);
        }
    }
}

static void FindMealPlan()
{
    while (true)
    {
        Console.WriteLine("Continue to find a meal plan? yes - 1, no - 0");
        var continueToPlanner = Convert.ToInt32(Console.ReadLine());

        if (continueToPlanner == 0)
        {
            break;
        }

        MealPlannerHandler.HandleInputFromConsole();
    }
}

static void FindRecipeByIngredients()
{
    while (true)
    {
        Console.WriteLine("Continue to find a recipe? yes - 1, no - 0");
        var continueToFind = Convert.ToInt32(Console.ReadLine());

        if (continueToFind == 0)
        {
            break;
        }

        RecipeFinderHandler.HandleInputFromConsole();
    }
}

static void ApproveRecipes()
{
    while (true)
    {
        Console.WriteLine("Continue to approve a recipe? yes - 1, no - 0");
        var continueToFind = Convert.ToInt32(Console.ReadLine());

        if (continueToFind == 0)
        {
            break;
        }

        RecipeApproverHandler.HandleInputFromConsole();
    }
}