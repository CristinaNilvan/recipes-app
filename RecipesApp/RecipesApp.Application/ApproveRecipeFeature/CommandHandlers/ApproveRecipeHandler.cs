using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.ApproveRecipeFeature.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.ApproveRecipeFeature.CommandHandlers
{
    public class ApproveRecipeHandler : IRequestHandler<ApproveRecipe, Recipe>
    {
        private readonly IRecipeRepository _repository;

        public ApproveRecipeHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Recipe> Handle(ApproveRecipe request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateRecipeStatus(request.RecipeId, true);
        }
    }
}