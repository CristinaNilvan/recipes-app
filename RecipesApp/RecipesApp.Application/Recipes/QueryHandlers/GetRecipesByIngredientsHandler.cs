using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetRecipesByIngredientsHandler : IRequestHandler<GetRecipesByIngredients, List<Recipe>>
    {
        private readonly IRecipeRepository _repository;

        public GetRecipesByIngredientsHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Recipe>> Handle(GetRecipesByIngredients request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetRecipesByIngredients(request.Ingredients));
        }
    }
}
