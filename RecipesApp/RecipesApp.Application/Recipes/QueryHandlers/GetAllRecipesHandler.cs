using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
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

        public Task<List<Recipe>> Handle(GetAllRecipes request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetAllRecipes());
        }
    }
}
