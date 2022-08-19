using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class DeleteIngredientHandler : IRequestHandler<DeleteIngredient, Ingredient>
    {
        private readonly IIngredientRepository _repository;

        public DeleteIngredientHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Ingredient> Handle(DeleteIngredient request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteIngredient(request.IngredientId);
        }
    }
}
