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

            var allRecipes = (await _unitOfWork
                .RecipeRepository
                .GetByApprovedStatusWithPagination(request.PaginationParameters, true))
                .ToList();
            var recipesWithIngredient = (await _unitOfWork
                .RecipeRepository
                .GetRecipesWithIngredientAndQuantity(request.PaginationParameters, quantityTwoDecimals, request.IngredientName))
                .ToList();
            var bestMatches = (await _unitOfWork
                .RecipeRepository
                .GetBestMatchRecipesWithIngredientAndQuantity(request.PaginationParameters, quantityTwoDecimals, request.IngredientName))
                .ToList();

            if (bestMatches.Count != 0)
            {
                return bestMatches;
            }
            else if (recipesWithIngredient.Count != 0)
            {
                return recipesWithIngredient;
            }
            else
            {
                return allRecipes;
            }
        }
    }
}
