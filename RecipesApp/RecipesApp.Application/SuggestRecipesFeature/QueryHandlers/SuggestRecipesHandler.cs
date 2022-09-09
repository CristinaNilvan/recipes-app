using MediatR;
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
            var quantityTwoDecimals = FeaturesUtils.CalculateTwoDecimalFloat(request.IngredientQuantity);
            var bestMatches = (await _unitOfWork
                .RecipeRepository
                .GetBestMatchByIngredientAndQuantity(request.PaginationParameters, quantityTwoDecimals, request.IngredientName))
                .ToList();

            if (bestMatches.Count != 0)
            {
                return bestMatches;
            }

            var recipesWithIngredient = (await _unitOfWork
                .RecipeRepository
                .GetByIngredientAndQuantity(request.PaginationParameters, quantityTwoDecimals, request.IngredientName))
                .ToList();

            if (recipesWithIngredient.Count != 0)
            {
                return recipesWithIngredient;
            }

            return null;
        }
    }
}
