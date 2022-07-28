using RecipesApp.Domain.Models;
using RecipesApp.Console.InputHandling;

var entities = "1 - Ingredient; 2 - Recipe";
var operations = "1 - Create; 2 - Read; 3 - Update; 4 - Delete";

Console.WriteLine("Hello!");

while (true)
{
    Console.WriteLine("Continue to choose an entity? yes - 5, no - 6");
    var continueEntity = Console.ReadLine();

    if (Convert.ToInt32(continueEntity) == 6)
    {
        break;
    }

    Console.WriteLine("Choose an entity: ");
    Console.WriteLine(entities);
    var chosenEntity = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"Chosen entity: {chosenEntity}");

    while (true)
    {
        Console.WriteLine("Continue to choose an operation? yes - 5, no - 6");
        var continueOperation = Console.ReadLine();

        if (Convert.ToInt32(continueOperation) == 6)
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