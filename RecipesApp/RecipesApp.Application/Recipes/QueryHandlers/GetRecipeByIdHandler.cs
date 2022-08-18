using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetRecipeByIdHandler : IRequestHandler<GetRecipeById, Recipe>
    {
        private readonly DataContext _dataContext;

        public GetRecipeByIdHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Recipe> Handle(GetRecipeById request, CancellationToken cancellationToken)
        {
            return await _dataContext.Recipes.SingleOrDefaultAsync(x => x.Id == request.RecipeId);
        }
    }
}
