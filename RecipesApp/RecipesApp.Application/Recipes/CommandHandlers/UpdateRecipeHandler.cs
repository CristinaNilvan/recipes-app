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
            var recipesWithRecipeIngredients = new List<RecipeWithRecipeIngredient>();

            foreach (var item in request.RecipeIngredients)
            {
                recipesWithRecipeIngredients.Add(new RecipeWithRecipeIngredient() { RecipeIngredientId = item.Id });
                var ingredient = await _unitOfWork.RecipeIngredientRepository.GetIngredientDetailsById(item.IngredientId);
                item.Ingredient = ingredient;
            }

            var recipe = new Recipe(request.RecipeId, request.Name, request.Author, request.Description, request.MealType,
                request.ServingTime, request.Servings, request.RecipeIngredients, recipesWithRecipeIngredients);

            await _unitOfWork.RecipeWithRecipeIngredientsRepository.DeleteRecipeIngredientsByRecipeId(request.RecipeId);
            await _unitOfWork.RecipeRepository.UpdateRecipe(recipe);
            await _unitOfWork.Save();

            return recipe;
        }
    }
}
