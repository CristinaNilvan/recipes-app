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
    public class DeleteIngredientHandler : IRequestHandler<DeleteIngredient>
    {
        private readonly IIngredientRepository _repository;

        public DeleteIngredientHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(DeleteIngredient request, CancellationToken cancellationToken)
        {
            _repository.DeleteIngredient(request.IngredientId);
            
            return Task.FromResult(Unit.Value);
        }
    }
}
