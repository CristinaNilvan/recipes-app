using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class RemoveRecipeIngredientsFromRecipeHandler : IRequestHandler<RemoveRecipeIngredientsFromRecipe, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveRecipeIngredientsFromRecipeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Recipe> Handle(RemoveRecipeIngredientsFromRecipe request, CancellationToken cancellationToken)
        {
            var recipe = await _unitOfWork.RecipeRepository.GetById(request.RecipeId);

            var recipeIngredients = new List<RecipeIngredient>();

            foreach (var recipeIngredientId in request.RecipeIngredientIds)
            {
                var recipeIngredient = await _unitOfWork
                .RecipeIngredientRepository
                .GetById(recipeIngredientId);

                recipeIngredients.Add(recipeIngredient);
            }

            if (recipe == null || recipeIngredients.Count == 0)
            {
                return null;
            }

            var recipeWithRecipeIngredients = new List<RecipeWithRecipeIngredient>();

            foreach (var recipeIngredient in recipeIngredients)
            {
                var recipeWithRecipeIngredient = await _unitOfWork
                .RecipeWithRecipeIngredientsRepository
                .GetByRecipeIdAndRecipeIngredientId(request.RecipeId, recipeIngredient.Id);

                recipeWithRecipeIngredients.Add(recipeWithRecipeIngredient);
            }

            foreach (var recipeWithRecipeIngredient in recipeWithRecipeIngredients)
            {
                var nutritionalValuesCalculator = new RecipeNutritionalValuesCalculator(recipe.Calories, recipe.Fats,
                recipe.Carbs, recipe.Proteins);
                nutritionalValuesCalculator.RemoveRecipeIngredientNutritionalValues(recipeWithRecipeIngredient);

                recipe.Calories = nutritionalValuesCalculator.Calories;
                recipe.Fats = nutritionalValuesCalculator.Fats;
                recipe.Carbs = nutritionalValuesCalculator.Carbs;
                recipe.Proteins = nutritionalValuesCalculator.Proteins;

                recipe.RemoveRecipeWithRecipeIngredient(recipeWithRecipeIngredient);
            }

            await _unitOfWork.Save();

            return recipe;
        }
    }
}
