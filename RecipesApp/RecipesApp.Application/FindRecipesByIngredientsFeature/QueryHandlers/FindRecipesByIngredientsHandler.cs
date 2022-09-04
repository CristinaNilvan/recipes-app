using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.FindRecipesByIngredientsFeature.Queries;
using RecipesApp.Application.Utils;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.FindRecipesByIngredientsFeature.QueryHandlers
{
    public class FindRecipesByIngredientsHandler : IRequestHandler<FindRecipesByIngredients, List<Recipe>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FindRecipesByIngredientsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Recipe>> Handle(FindRecipesByIngredients request, CancellationToken cancellationToken)
        {
            var getByPaginationParameters = new PaginationParameters { PageNumber = 0 };
            var filteredRecipes = new List<Recipe>();
            var approvedRecipes = await _unitOfWork.RecipeRepository.GetByApprovedStatus(getByPaginationParameters, true);

            foreach (var recipe in approvedRecipes)
            {
                var recipeIngredientsIds = await _unitOfWork
                    .RecipeRepository
                    .GetIngredientIdsOfRecipe(recipe.Name, recipe.Author);

                var containsAll = FeaturesUtils
                    .CheckIfRecipeContainsAllIngredients(recipeIngredientsIds, request.IngredientIds);

                if (containsAll)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            if (filteredRecipes.Count != 0)
            {
                return filteredRecipes;
            }
            else
            {
                return approvedRecipes;
            }
        }
    }
}