using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Application.Utils;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class AddRecipeIngredientToRecipeHandler : IRequestHandler<AddRecipeIngredientToRecipe, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddRecipeIngredientToRecipeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Recipe> Handle(AddRecipeIngredientToRecipe request, CancellationToken cancellationToken)
        {
            var recipe = await _unitOfWork.RecipeRepository.GetById(request.RecipeId);
            var recipeIngredient = await _unitOfWork
                .RecipeIngredientRepository
                .GetById(request.RecipeIngredientId);

            if (recipe == null || recipeIngredient == null)
            {
                return null;
            }

            var recipeWithRecipeIngredient = new RecipeWithRecipeIngredient
            {
                RecipeId = request.RecipeId,
                Recipe = recipe,
                RecipeIngredientId = request.RecipeIngredientId,
                RecipeIngredient = recipeIngredient
            };

            var nutritionalValuesCalculator = new RecipeNutritionalValuesCalculator(recipe);
            nutritionalValuesCalculator.AddRecipeWithRecipeIngredient(recipeWithRecipeIngredient);

            //recipe.AddRecipeWithRecipeIngredient(recipeWithRecipeIngredient);
            await _unitOfWork.Save();

            return recipe;
        }
    }
}
