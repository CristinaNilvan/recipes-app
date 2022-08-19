using MediatR;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Recipe>> Handle(GetRecipesByApprovedStatus request, CancellationToken cancellationToken)
        {
            return await _repository.GetRecipesByApprovedStatus(request.ApprovedStatus);
        }
    }
}
