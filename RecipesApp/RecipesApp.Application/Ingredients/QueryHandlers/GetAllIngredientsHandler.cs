using MediatR;
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

        public Task<List<Ingredient>> Handle(GetAllIngredients request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetAllIngredients());
        }
    }
}
