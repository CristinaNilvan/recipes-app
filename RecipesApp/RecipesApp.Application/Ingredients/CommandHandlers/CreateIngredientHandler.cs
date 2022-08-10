using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class CreateIngredientHandler : IRequestHandler<CreateIngredient>
    {
        private readonly IIngredientRepository _repository;

        public CreateIngredientHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient(request.Name, request.Category, request.Calories, request.Fats, request.Carbs,
                request.Proteins);

            await _repository.CreateIngredient(ingredient);

            return new Unit();
        }
    }
}
