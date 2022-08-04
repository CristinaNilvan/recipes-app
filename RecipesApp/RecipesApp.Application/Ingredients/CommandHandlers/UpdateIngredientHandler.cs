using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class UpdateIngredientHandler : IRequestHandler<UpdateIngredient>
    {
        private readonly IIngredientRepository _repository;

        public UpdateIngredientHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(UpdateIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient(request.Name, request.Category, request.Calories, request.Fats, request.Carbs,
                request.Proteins);

            _repository.UpdateIngredient(request.IngredientId, ingredient);

            return Task.FromResult(Unit.Value);
        }
    }
}
