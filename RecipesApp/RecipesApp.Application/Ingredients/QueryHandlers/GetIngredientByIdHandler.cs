using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure;

namespace RecipesApp.Application.Ingredients.QueryHandlers
{
    public class GetIngredientByIdHandler : IRequestHandler<GetIngredientById, Ingredient>
    {
        private readonly DataContext _dataContext;

        public GetIngredientByIdHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Ingredient> Handle(GetIngredientById request, CancellationToken cancellationToken)
        {
            return await _dataContext.Ingredients.SingleOrDefaultAsync(x => x.Id == request.IngredientId);
        }
    }
}