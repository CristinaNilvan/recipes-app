using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetUnapprovedRecipesHandler : IRequestHandler<GetUnapprovedRecipes, List<Recipe>>
    {
        private readonly IRecipeRepository _repository;

        public GetUnapprovedRecipesHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Recipe>> Handle(GetUnapprovedRecipes request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetUnapprovedRecipes());
        }
    }
}
