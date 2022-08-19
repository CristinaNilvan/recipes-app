using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetRecipeByNameHandler : IRequestHandler<GetRecipeByName, Recipe>
    {
        private readonly IRecipeRepository _repository;

        public GetRecipeByNameHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Recipe> Handle(GetRecipeByName request, CancellationToken cancellationToken)
        {
            return await _repository.GetRecipeByName(request.RecipeName);
        }
    }
}
