using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class UpdateIngredientHandler : IRequestHandler<UpdateIngredient>
    {
        private readonly IIngredientRepository _repository;

        public UpdateIngredientHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient(request.Name, request.Category, request.Calories, request.Fats, request.Carbs,
                request.Proteins);

            await _repository.UpdateIngredient(request.IngredientId, ingredient);

            return new Unit();
        }
    }
}
