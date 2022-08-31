using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.ApproveRecipeFeature.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.ApproveRecipeFeature.CommandHandlers
{
    public class ApproveRecipeHandler : IRequestHandler<ApproveRecipe, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApproveRecipeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Recipe> Handle(ApproveRecipe request, CancellationToken cancellationToken)
        {
            var recipe = await _unitOfWork.RecipeRepository.GetById(request.RecipeId);

            if (recipe == null)
            {
                return null;
            }

            await _unitOfWork.RecipeRepository.UpdateApprovedStatus(recipe, true);
            await _unitOfWork.Save();

            return recipe;
        }
    }
}