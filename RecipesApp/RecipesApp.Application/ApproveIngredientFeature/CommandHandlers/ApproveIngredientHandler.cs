using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.ApproveIngredientFeature.Commands;

namespace RecipesApp.Application.ApproveIngredientFeature.CommandHandlers
{
    public class ApproveIngredientHandler : IRequestHandler<ApproveIngredient>
    {
        private readonly IIngredientRepository _repository;

        public ApproveIngredientHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(ApproveIngredient request, CancellationToken cancellationToken)
        {
            _repository.UpdateIngredientStatus(request.IngredientId, true);

            return Task.FromResult(Unit.Value);
        }
    }
}
