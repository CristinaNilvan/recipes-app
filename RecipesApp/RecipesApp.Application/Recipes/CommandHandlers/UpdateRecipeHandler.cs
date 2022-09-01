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
            var previousRecipe = await _unitOfWork.IngredientRepository.GetById(request.Id);

            if (previousRecipe == null)
            {
                return null;
            }

            var updatedRecipe = new Recipe(request.Id, request.Name, request.Author, request.Description,
                request.MealType, request.ServingTime, request.Servings);

            await _unitOfWork.RecipeWithRecipeIngredientsRepository.DeleteByRecipeId(request.Id);
            await _unitOfWork.RecipeRepository.Update(updatedRecipe);
            await _unitOfWork.Save();

            return updatedRecipe;
        }
    }
}
