using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class DeleteRecipeHandler : IRequestHandler<DeleteRecipe>
    {
        private readonly IRecipeRepository _repository;

        public DeleteRecipeHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(DeleteRecipe request, CancellationToken cancellationToken)
        {
            _repository.DeleteRecipe(request.RecipeId);

            return Task.FromResult(Unit.Value);
        }
    }
}
