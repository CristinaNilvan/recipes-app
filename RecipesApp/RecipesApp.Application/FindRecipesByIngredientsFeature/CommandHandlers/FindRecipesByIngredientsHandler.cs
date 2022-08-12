using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.FindRecipesByIngredientsFeature.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.FindRecipesByIngredientsFeature.CommandHandlers
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

            foreach (var recipe in approvedRecipes)
            {
                var containsAll = CheckIfRecipeContainsAllIngredients(recipe.Ingredients, request.Ingredients);

                if (containsAll)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes;
        }

        private bool CheckIfRecipeContainsAllIngredients(List<Ingredient> recipeIngredientList, List<Ingredient> givenIngredientList)
        {
            return givenIngredientList.All(x => recipeIngredientList.Any(y => x.Id == y.Id));
        }
    }
}