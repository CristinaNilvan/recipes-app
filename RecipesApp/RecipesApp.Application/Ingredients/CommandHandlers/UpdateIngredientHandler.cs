using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class UpdateIngredientHandler : IRequestHandler<UpdateIngredient, Ingredient>
    {
        private readonly IIngredientRepository _repository;

        public UpdateIngredientHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Ingredient> Handle(UpdateIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient(request.IngredientId, request.Name, request.Category, request.Calories, request.Fats, 
                request.Carbs, request.Proteins);

            return await _repository.UpdateIngredient(ingredient);
        }
    }
}
