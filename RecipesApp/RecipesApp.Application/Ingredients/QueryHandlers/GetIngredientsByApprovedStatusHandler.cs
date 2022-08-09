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

        public Task<List<Ingredient>> Handle(GetIngredientsByApprovedStatus request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetIngredientsByApprovedStatus(request.ApprovedStatus));
        }
    }
}
