using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class DeleteRecipeHandler : IRequestHandler<DeleteRecipe, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRecipeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Recipe> Handle(DeleteRecipe request, CancellationToken cancellationToken)
        {
            var recipe = await _unitOfWork.RecipeRepository.GetById(request.RecipeId);

            if (recipe == null)
            {
                return null;
            }

            await _unitOfWork.RecipeRepository.Delete(recipe);
            await _unitOfWork.Save();

            return recipe;
        }
    }
}
