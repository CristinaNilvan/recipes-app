using RecipesApp.Console.InputHandling;

Console.WriteLine("Hello!");

while (true)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1 - do CRUD on entities");
    Console.WriteLine("2 - find a meal plan");
    Console.WriteLine("3 - find a recipe by ingredients");
    Console.WriteLine("4 - exit");

    var nextOperation = Convert.ToInt32(Console.ReadLine());
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
        FindRecipeByIngredients();
    }
    else if (nextOperation == 4)
    {
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