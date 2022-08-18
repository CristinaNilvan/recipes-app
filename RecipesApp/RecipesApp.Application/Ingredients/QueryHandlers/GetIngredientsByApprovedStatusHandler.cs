using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure;

namespace RecipesApp.Application.Ingredients.QueryHandlers
{
    public class GetIngredientsByApprovedStatusHandler : IRequestHandler<GetIngredientsByApprovedStatus, List<Ingredient>>
    {
        private readonly DataContext _dataContext;

        public GetIngredientsByApprovedStatusHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Ingredient>> Handle(GetIngredientsByApprovedStatus request, CancellationToken cancellationToken)
        {
            return await _dataContext.Ingredients.Where(x => x.Approved == request.ApprovedStatus).ToListAsync();
        }
    }
}
