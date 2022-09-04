﻿using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.SuggestRecipesFeature.Queries;
using RecipesApp.Application.Utils;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.SuggestRecipesFeature.QueryHandlers
{
    public class SuggestRecipesHandler : IRequestHandler<SuggestRecipes, List<Recipe>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuggestRecipesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Recipe>> Handle(SuggestRecipes request, CancellationToken cancellationToken)
        {
            var getByPaginationParameters = new PaginationParameters { PageNumber = 0 };
            var quantityTwoDecimals = FeaturesUtils.CalculateTwoDecimalFloat(request.IngredientQuantity);

            var allRecipes = await _unitOfWork
                .RecipeRepository
                .GetByApprovedStatus(getByPaginationParameters, true);
            var recipesWithIngredient = await _unitOfWork
                .RecipeRepository
                .GetRecipesWithInredientAndQuantity(quantityTwoDecimals, request.IngredientName);
            var bestMatches = await _unitOfWork
                .RecipeRepository
                .GetBestMatchRecipesWithInredientAndQuantity(quantityTwoDecimals, request.IngredientName);

            if (bestMatches.Count != 0)
            {
                return FeaturesUtils.DoPaginationOnRecipes(bestMatches, request.PaginationParameters);
            }
            else if (recipesWithIngredient.Count != 0)
            {
                return FeaturesUtils.DoPaginationOnRecipes(recipesWithIngredient, request.PaginationParameters);
            }
            else
            {
                return FeaturesUtils.DoPaginationOnRecipes(allRecipes, request.PaginationParameters);
            }
        }
    }
}
