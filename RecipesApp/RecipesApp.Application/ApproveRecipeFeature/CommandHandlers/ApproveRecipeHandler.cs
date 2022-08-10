using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.ApproveRecipeFeature.Commands;

namespace RecipesApp.Application.ApproveRecipeFeature.CommandHandlers
{
    public class ApproveRecipeHandler : IRequestHandler<ApproveRecipe>
    {
        private readonly IRecipeRepository _repository;

        public ApproveRecipeHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ApproveRecipe request, CancellationToken cancellationToken)
        {
            await _repository.UpdateRecipeStatus(request.RecipeId, true);

            return new Unit();
        }
    }
}