using RecipesApp.Domain.Models;
using RecipesApp.Console.BusinessLogic;

var entities = "1 - Ingredient; 2 - Recipe";
var operations = "1 - Create; 2 - Update; 3 - Delete";

Console.WriteLine("Hello!");

while (true)
{
    Console.WriteLine("Continue to choose an entity? yes - 4, no - 5");
    var continueEntity = Console.ReadLine();

    if (Convert.ToInt32(continueEntity) == 5)
    {
        break;
    }

    Console.WriteLine("Choose an entity: ");
    Console.WriteLine(entities);
    var chosenEntity = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"Chosen entity: {chosenEntity}");

    while (true)
    {
        Console.WriteLine("Continue to choose an operation? yes - 4, no - 5");
        var continueOperation = Console.ReadLine();

        if (Convert.ToInt32(continueOperation) == 5)
        {
            break;
        }

        Console.WriteLine("Choose an operation: ");
        Console.WriteLine(operations);
        var chosenOperation = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Chosen operation: {chosenOperation}");

        HandleInput.HandleInputFromConsole(chosenEntity, chosenOperation);
    }
}