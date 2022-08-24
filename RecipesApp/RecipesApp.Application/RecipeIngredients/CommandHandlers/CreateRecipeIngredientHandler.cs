using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.RecipeIngredients.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.RecipeIngredients.CommandHandlers
{
    public class CreateRecipeIngredientHandler : IRequestHandler<CreateRecipeIngredient, RecipeIngredient>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRecipeIngredientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RecipeIngredient> Handle(CreateRecipeIngredient request, CancellationToken cancellationToken)
        {
            var recipeIngredient = new RecipeIngredient(request.Quantity, request.IngredientId);

            await _unitOfWork.RecipeIngredientRepository.CreateRecipeIngredient(recipeIngredient);
            await _unitOfWork.Save();

            return recipeIngredient;
        }
    }
}
