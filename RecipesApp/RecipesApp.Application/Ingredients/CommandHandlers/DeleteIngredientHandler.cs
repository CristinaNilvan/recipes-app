using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class DeleteIngredientHandler : IRequestHandler<DeleteIngredient, Ingredient>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteIngredientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Ingredient> Handle(DeleteIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = await _unitOfWork.IngredientRepository.GetIngredientById(request.IngredientId);

            await _unitOfWork.IngredientRepository.DeleteIngredient(ingredient);
            await _unitOfWork.Save();

            return ingredient;
        }
    }
}
