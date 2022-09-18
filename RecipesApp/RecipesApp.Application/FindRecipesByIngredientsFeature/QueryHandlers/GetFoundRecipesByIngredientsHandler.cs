using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.FindRecipesByIngredientsFeature.Queries;
using RecipesApp.Application.Utils;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.FindRecipesByIngredientsFeature.QueryHandlers
{
    public class GetFoundRecipesByIngredientsHandler : IRequestHandler<GetFoundRecipesByIngredients, List<Recipe>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFoundRecipesByIngredientsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Recipe>> Handle(GetFoundRecipesByIngredients request, CancellationToken cancellationToken)
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

                var containsAll = CheckIfRecipeContainsAllIngredients(recipeIngredientsIds, request.IngredientIds);

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

        private bool CheckIfRecipeContainsAllIngredients(List<int> recipeIngredientList,
            List<int> givenIngredientList)
            => givenIngredientList
                .All(givenItem => recipeIngredientList
                .Any(recipeIngredientItem => givenItem == recipeIngredientItem));
    }
}