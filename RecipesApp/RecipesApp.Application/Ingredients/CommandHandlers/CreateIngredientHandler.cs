using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Application.Utils;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class CreateIngredientHandler : IRequestHandler<CreateIngredient, Ingredient>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateIngredientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Ingredient> Handle(CreateIngredient request, CancellationToken cancellationToken)
        {
            request.Calories = UsedFunctions.CalculateTwoDecimalFloat(request.Calories);
            request.Fats = UsedFunctions.CalculateTwoDecimalFloat(request.Fats);
            request.Carbs = UsedFunctions.CalculateTwoDecimalFloat(request.Carbs);
            request.Proteins = UsedFunctions.CalculateTwoDecimalFloat(request.Proteins);

            var ingredient = new Ingredient(request.Name, request.Category, request.Calories, request.Fats, request.Carbs,
                request.Proteins);

            await _unitOfWork.IngredientRepository.Create(ingredient);
            await _unitOfWork.Save();

            return ingredient;
        }
    }
}
