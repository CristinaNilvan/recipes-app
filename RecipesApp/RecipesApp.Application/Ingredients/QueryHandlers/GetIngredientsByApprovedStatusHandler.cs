using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.QueryHandlers
{
    public class GetIngredientsByApprovedStatusHandler : IRequestHandler<GetIngredientsByApprovedStatus, List<Ingredient>>
    {
        private readonly IIngredientRepository _repository;

        public GetIngredientsByApprovedStatusHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Ingredient>> Handle(GetIngredientsByApprovedStatus request, CancellationToken cancellationToken)
        {
            return await _repository.GetIngredientsByApprovedStatus(request.ApprovedStatus);
        }
    }
}
