using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetAllRecipesHandler : IRequestHandler<GetAllRecipes, List<Recipe>>
    {
        private readonly IRecipeRepository _repository;

        public GetAllRecipesHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Recipe>> Handle(GetAllRecipes request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllRecipes();
        }
    }
}
