using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetAllRecipesHandler : IRequestHandler<GetAllRecipes, List<Recipe>>
    {
        private readonly DataContext _dataContext;

        public GetAllRecipesHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Recipe>> Handle(GetAllRecipes request, CancellationToken cancellationToken)
        {
            return await _dataContext.Recipes.ToListAsync();
        }
    }
}
