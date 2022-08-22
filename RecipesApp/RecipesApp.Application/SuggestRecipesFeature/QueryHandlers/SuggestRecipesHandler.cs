using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.SuggestRecipesFeature.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.SuggestRecipesFeature.QueryHandlers
{
    public class SuggestRecipesHandler : IRequestHandler<SuggestRecipes, List<Recipe>>
    {
        private readonly IRecipeRepository _repository;

        public SuggestRecipesHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Recipe>> Handle(SuggestRecipes request, CancellationToken cancellationToken)
        {
            var quantityTwoDecimals = RecipesSuggesterUtils.CalculateTwoDecimalFloat(request.IngredientQuantity);

            var allRecipes = await _repository.GetRecipesByApprovedStatus(true);
            var recipesWithIngredient = await _repository.GetRecipesWithInredientAndQuantity(quantityTwoDecimals,
                request.IngredientName);
            var bestMatches = await _repository.GetBestMatchRecipesWithInredientAndQuantity(quantityTwoDecimals,
                request.IngredientName);

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
