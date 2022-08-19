using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.ApproveIngredientFeature.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.ApproveIngredientFeature.CommandHandlers
{
    public class ApproveIngredientHandler : IRequestHandler<ApproveIngredient, Ingredient>
    {
        private readonly IIngredientRepository _repository;

        public ApproveIngredientHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Ingredient> Handle(ApproveIngredient request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateIngredientStatus(request.IngredientId, true);
        }
    }
}
