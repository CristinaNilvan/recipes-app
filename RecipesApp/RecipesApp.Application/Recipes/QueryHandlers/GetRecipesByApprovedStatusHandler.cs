using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetRecipesByApprovedStatusHandler : IRequestHandler<GetRecipesByApprovedStatus, List<Recipe>>
    {
        private readonly DataContext _dataContext;

        public GetRecipesByApprovedStatusHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Recipe>> Handle(GetRecipesByApprovedStatus request, CancellationToken cancellationToken)
        {
            return await _dataContext.Recipes.Where(x => x.Approved == request.ApprovedStatus).ToListAsync();
        }
    }
}
