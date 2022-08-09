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

        public Task<List<Recipe>> Handle(SuggestRecipes request, CancellationToken cancellationToken)
        {
            var recipes = _repository.GetApprovedRecipes();
            var filteredByIngredientName = RecipesSuggesterUtils.FilterByIngredientName(request.IngredientName, recipes);
            var filteredByIngredientQuantity = RecipesSuggesterUtils.FilterByIngredientQuantity(request.Quantity, filteredByIngredientName);

            if (filteredByIngredientQuantity.Count == 0)
            {
                return Task.FromResult(filteredByIngredientName);
            }
            else
            {
                return Task.FromResult(filteredByIngredientQuantity);
            }
        }
    }
}
