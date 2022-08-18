using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure;

namespace RecipesApp.Application.Ingredients.QueryHandlers
{
    public class GetAllIngredientsHandler : IRequestHandler<GetAllIngredients, List<Ingredient>>
    {
        private readonly DataContext _dataContext;

        public GetAllIngredientsHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Ingredient>> Handle(GetAllIngredients request, CancellationToken cancellationToken)
        {
            return await _dataContext.Ingredients.ToListAsync();
        }
    }
}
