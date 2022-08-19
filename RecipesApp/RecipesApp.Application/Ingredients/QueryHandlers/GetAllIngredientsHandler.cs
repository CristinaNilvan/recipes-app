using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.QueryHandlers
{
    public class GetAllIngredientsHandler : IRequestHandler<GetAllIngredients, List<Ingredient>>
    {
        private readonly IIngredientRepository _repository;

        public GetAllIngredientsHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Ingredient>> Handle(GetAllIngredients request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllIngredients();
        }
    }
}
