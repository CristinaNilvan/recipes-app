using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class UpdateIngredientHandler : IRequestHandler<UpdateIngredient, Ingredient>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateIngredientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Ingredient> Handle(UpdateIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = await _unitOfWork.IngredientRepository.GetById(request.Id);

            if (ingredient == null)
            {
                return null;
            }

            ingredient.Name = request.Name ?? ingredient.Name;
            ingredient.Category = request.Category ?? ingredient.Category;
            ingredient.Calories = request.Calories ?? ingredient.Calories;
            ingredient.Fats = request.Fats ?? ingredient.Fats;
            ingredient.Carbs = request.Carbs ?? ingredient.Carbs;
            ingredient.Proteins = request.Proteins ?? ingredient.Proteins;
            ingredient.Approved = false;

            await _unitOfWork.Save();

            return ingredient;
        }
    }
}
