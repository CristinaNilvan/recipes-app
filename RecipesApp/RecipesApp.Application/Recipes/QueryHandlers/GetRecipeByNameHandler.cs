using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetRecipeByNameHandler : IRequestHandler<GetRecipeByName, Recipe>
    {
        private readonly DataContext _dataContext;

        public GetRecipeByNameHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Recipe> Handle(GetRecipeByName request, CancellationToken cancellationToken)
        {
            return await _dataContext.Recipes.SingleOrDefaultAsync(x => x.Name == request.RecipeName);
        }
    }
}
