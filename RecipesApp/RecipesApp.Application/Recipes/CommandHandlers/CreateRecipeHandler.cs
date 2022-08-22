using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class CreateRecipeHandler : IRequestHandler<CreateRecipe, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRecipeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Recipe> Handle(CreateRecipe request, CancellationToken cancellationToken)
        {
            var recipe = new Recipe(request.Name, request.Author, request.Description, request.MealType, request.ServingTime,
                request.Servings);

            return await _unitOfWork.RecipeRepository.CreateRecipe(recipe, request.RecipeIngredients);
        }
    }
}
