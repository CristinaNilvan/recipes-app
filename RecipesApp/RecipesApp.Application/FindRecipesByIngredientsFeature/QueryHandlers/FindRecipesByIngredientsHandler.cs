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
            var recipesWithAllIngredients = new List<Recipe>();
            var recipesContainingIngredients = (await _unitOfWork
                .RecipeRepository
                .GetByContainingOneOfGivenIngredients(request.IngredientIds))
                .ToList();

            foreach (var recipe in recipesContainingIngredients)
            {
                var recipeIngredientsIds = (await _unitOfWork
                    .RecipeRepository
                    .GetIngredientIdsByRecipeId(recipe.Id))
                    .ToList();

                var containsAll = UsedFunctions
                    .CheckIfRecipeContainsAllIngredients(recipeIngredientsIds, request.IngredientIds);

                if (containsAll)
                {
                    recipesWithAllIngredients.Add(recipe);
                }
            }

            if (recipesWithAllIngredients.Count != 0)
            {
                return recipesWithAllIngredients;
            }
            else if (recipesContainingIngredients.Count != 0)
            {
                return recipesContainingIngredients;
            }
            else
            {
                return null;
            }
        }
    }
}