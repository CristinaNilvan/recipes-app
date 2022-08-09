using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetRecipesByApprovedStatusHandler : IRequestHandler<GetRecipesByApprovedStatus, List<Recipe>>
    {
        private readonly IRecipeRepository _repository;

        public GetRecipesByApprovedStatusHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Recipe>> Handle(GetRecipesByApprovedStatus request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetRecipesByApprovedStatus(request.ApprovedStatus));
        }
    }
}
