using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.QueryHandlers
{
    public class GetIngredientByNameHandler : IRequestHandler<GetIngredientByName, Ingredient>
    {
        private readonly IIngredientRepository _repository;

        public GetIngredientByNameHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Ingredient> Handle(GetIngredientByName request, CancellationToken cancellationToken)
        {
            return await _repository.GetIngredientByName(request.IngredientName);
        }
    }
}
