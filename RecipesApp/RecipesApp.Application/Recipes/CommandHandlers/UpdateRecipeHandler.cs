using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class UpdateRecipeHandler : IRequestHandler<UpdateRecipe, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRecipeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Recipe> Handle(UpdateRecipe request, CancellationToken cancellationToken)
        {
            var recipe = new Recipe(request.Name, request.Author, request.Description, request.MealType, request.ServingTime,
                request.Servings);

            return await _unitOfWork.RecipeRepository.UpdateRecipe(recipe, request.RecipeIngredients);
        }
    }
}
