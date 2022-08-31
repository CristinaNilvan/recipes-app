﻿using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class UpdateRecipeHandler : IRequestHandler<UpdateRecipe, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRecipeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Recipe> Handle(UpdateRecipe request, CancellationToken cancellationToken)
        {
            var previousRecipe = await _unitOfWork.IngredientRepository.GetById(request.RecipeId);

            if (previousRecipe == null)
            {
                return null;
            }

            var updatedRecipe = new Recipe(request.RecipeId, request.Name, request.Author, request.Description,
                request.MealType, request.ServingTime, request.Servings);

            await _unitOfWork.RecipeWithRecipeIngredientsRepository.DeleteByRecipeId(request.RecipeId);
            await _unitOfWork.RecipeRepository.Update(updatedRecipe);
            await _unitOfWork.Save();

            return updatedRecipe;
        }
    }
}
