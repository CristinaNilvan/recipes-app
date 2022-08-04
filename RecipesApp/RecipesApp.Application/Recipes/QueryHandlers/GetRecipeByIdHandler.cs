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
    public class GetRecipeByIdHandler : IRequestHandler<GetRecipeById, Recipe>
    {
        private readonly IRecipeRepository _repository;

        public GetRecipeByIdHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public Task<Recipe> Handle(GetRecipeById request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetRecipeById(request.RecipeId));
        }
    }
}
