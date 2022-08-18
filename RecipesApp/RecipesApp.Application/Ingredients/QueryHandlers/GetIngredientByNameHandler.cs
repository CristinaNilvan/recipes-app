using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure;

namespace RecipesApp.Application.Ingredients.QueryHandlers
{
    public class GetIngredientByNameHandler : IRequestHandler<GetIngredientByName, Ingredient>
    {
        private readonly DataContext _dataContext;

        public GetIngredientByNameHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Ingredient> Handle(GetIngredientByName request, CancellationToken cancellationToken)
        {
            return await _dataContext.Ingredients.SingleOrDefaultAsync(x => x.Name == request.IngredientName);
        }
    }
}
