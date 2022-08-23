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
            var recipesWithRecipeIngredients = new List<RecipeWithRecipeIngredient>();

            foreach (var item in request.RecipeIngredients)
            {
                recipesWithRecipeIngredients.Add(new RecipeWithRecipeIngredient() { RecipeIngredientId = item.Id });
            }

            var recipe = new Recipe(request.Name, request.Author, request.Description, request.MealType, request.ServingTime,
                request.Servings, recipesWithRecipeIngredients);

            await _unitOfWork.RecipeRepository.CreateRecipe(recipe, request.RecipeIngredients);
            await _unitOfWork.Save();

            return recipe;
        }
    }
}
