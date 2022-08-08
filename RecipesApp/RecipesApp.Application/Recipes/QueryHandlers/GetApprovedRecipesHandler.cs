using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    internal class GetApprovedRecipesHandler : IRequestHandler<GetApprovedRecipes, List<Recipe>>
    {
        private readonly IRecipeRepository _repository;

        public GetApprovedRecipesHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Recipe>> Handle(GetApprovedRecipes request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetApprovedRecipes());
        }
    }
}
