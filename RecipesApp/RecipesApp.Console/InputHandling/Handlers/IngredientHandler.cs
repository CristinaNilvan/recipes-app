using MediatR;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Console.InputHandling.Utils;
using RecipesApp.Domain.Enums;

namespace RecipesApp.Console.InputHandling.Handlers
{
    internal class IngredientHandler
    {
        private static readonly IMediator _mediator = MediatorSetup.GetMediator();

        public static async void HandleCreateIngredient()
        {
            var ingredient = InputHandlingUtils.CreateIngredientFromInput();

            await _mediator.Send(new CreateIngredient()
            {
                Name = ingredient.Name,
                Category = ingredient.Category,
                Calories = ingredient.Calories,
                Fats = ingredient.Fats,
                Carbs = ingredient.Carbs,
                Proteins = ingredient.Proteins
            });
        }

        public static async void HandleReadIngredient()
        {
            System.Console.WriteLine("Please enter the id: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            var ingredient = await _mediator.Send(new GetIngredientById()
            {
                IngredientId = id
            });

            System.Console.WriteLine(ingredient);
        }

        public static async void HandleUpdateIngredient()
        {
            HandleReadAllIngredients();

            System.Console.WriteLine("Enter the id of the element you want to update: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            var ingredient = InputHandlingUtils.CreateIngredientFromInput();

            await _mediator.Send(new UpdateIngredient()
            {
                IngredientId = id,
                Name = ingredient.Name,
                Category = ingredient.Category,
                Calories = ingredient.Calories,
                Fats = ingredient.Fats,
                Carbs = ingredient.Carbs,
                Proteins = ingredient.Proteins
            });
        }

        public static async void HandleDeleteIngredient()
        {
            HandleReadAllIngredients();

            System.Console.WriteLine("Enter the id of the element you want to delete: ");
            var id = Convert.ToInt32(System.Console.ReadLine());

            await _mediator.Send(new DeleteIngredient()
            {
                IngredientId = id
            });
        }

        public static async void HandleReadAllIngredients()
        {
            System.Console.WriteLine("Here are the current ingredients: ");
            var ingredients = await _mediator.Send(new GetAllIngredients());
            ListPrinter.PrintList(ingredients);
        }
    }
}
