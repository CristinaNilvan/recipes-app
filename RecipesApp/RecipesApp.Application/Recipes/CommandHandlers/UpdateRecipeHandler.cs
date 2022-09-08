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
            var recipe = await _unitOfWork.RecipeRepository.GetById(request.Id);

            if (recipe == null)
            {
                return null;
            }

            recipe.Name = request.Name ?? recipe.Name;
            recipe.Author = request.Author ?? recipe.Author;
            recipe.Description = request.Description ?? recipe.Description;
            recipe.MealType = request.MealType ?? recipe.MealType;
            recipe.ServingTime = request.ServingTime ?? recipe.ServingTime;
            recipe.Servings = request.Servings ?? recipe.Servings;
            recipe.Approved = false;

            await _unitOfWork.Save();

            return recipe;
        }
    }
}
