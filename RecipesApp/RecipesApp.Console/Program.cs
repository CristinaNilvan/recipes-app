using RecipesApp.Domain.Models;
using RecipesApp.Console.InputHandling;

var entities = "1 - Ingredient; 2 - Recipe";
var operations = "1 - Create; 2 - Read; 3 - Update; 4 - Delete";

Console.WriteLine("Hello!");

while (true)
{
    Console.WriteLine("Continue to choose an entity? yes - 1, no - 0");
    var continueToEntity = Console.ReadLine();

    if (Convert.ToInt32(continueToEntity) == 0)
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
        var continueToOperation = Console.ReadLine();

        if (Convert.ToInt32(continueToOperation) == 0)
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