using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
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
            var ingredient = new Ingredient(request.Name, request.Category, request.Calories, request.Fats, request.Carbs,
                request.Proteins);

            await _unitOfWork.IngredientRepository.Create(ingredient);
            await _unitOfWork.Save();

            return ingredient;
        }
    }
}
