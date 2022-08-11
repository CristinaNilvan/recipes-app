using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.SuggestRecipesFeature.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.SuggestRecipesFeature.CommandHandlers
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
            var recipesWithIngredient = RecipesSuggesterUtils.FilterByIngredientAndQuantity(request.IngredientName,
                quantityTwoDecimals, allRecipes);
            var bestMatches = RecipesSuggesterUtils.FilterByBestMatch(request.IngredientName, quantityTwoDecimals,
                recipesWithIngredient);

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
