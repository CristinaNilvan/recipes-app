using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class RemoveRecipeIngredientFromRecipeHandler : IRequestHandler<RemoveRecipeIngredientFromRecipe, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveRecipeIngredientFromRecipeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Recipe> Handle(RemoveRecipeIngredientFromRecipe request, CancellationToken cancellationToken)
        {
            var recipe = await _unitOfWork.RecipeRepository.GetRecipeById(request.RecipeId);
            var recipeIngredient = await _unitOfWork.RecipeIngredientRepository.GetRecipeIngredientById(
                request.RecipeIngredientId);

            if (recipe == null || recipeIngredient == null)
            {
                return null;
            }

            var recipeWithRecipeIngredient = await _unitOfWork
                .RecipeWithRecipeIngredientsRepository
                .GetByRecipeIdAndRecipeIngredientId(request.RecipeId, request.RecipeIngredientId);

            recipe.RemoveRecipeWithRecipeIngredient(recipeWithRecipeIngredient);
            await _unitOfWork.Save();

            return recipe;
        }
    }
}
