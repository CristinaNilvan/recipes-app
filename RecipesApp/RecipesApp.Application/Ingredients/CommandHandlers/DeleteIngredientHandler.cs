using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class DeleteIngredientHandler : IRequestHandler<DeleteIngredient>
    {
        private readonly IIngredientRepository _repository;

        public DeleteIngredientHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteIngredient request, CancellationToken cancellationToken)
        {
            await _repository.DeleteIngredient(request.IngredientId);

            return new Unit();
        }
    }
}
