using MediatR;
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

        public Task<Ingredient> Handle(GetIngredientByName request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetIngredientByName(request.IngredientName));
        }
    }
}
