using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.FindRecipesByIngredientsFeature.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.FindRecipesByIngredientsFeature.QueryHandlers
{
    public class FindRecipesByIngredientsHandler : IRequestHandler<FindRecipesByIngredients, List<Recipe>>
    {
        private readonly IRecipeRepository _repository;

        public FindRecipesByIngredientsHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Recipe>> Handle(FindRecipesByIngredients request, CancellationToken cancellationToken)
        {
            var approvedRecipes = await _repository.GetRecipesByApprovedStatus(true);
            var filteredRecipes = new List<Recipe>();

            var ingredientIds = RecipesFinderUtils.GetIngredientIds(request.Ingredients);

            foreach (var recipe in approvedRecipes)
            {
                var recipeIngredientsIds = await _repository.GetIngredientIdsOfRecipe(recipe.Name, recipe.Author);
                var containsAll = RecipesFinderUtils.CheckIfRecipeContainsAllIngredients(recipeIngredientsIds, ingredientIds);

                if (containsAll)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes;
        }
    }
}