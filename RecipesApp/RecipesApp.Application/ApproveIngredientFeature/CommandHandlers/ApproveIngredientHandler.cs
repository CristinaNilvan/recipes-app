using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.ApproveIngredientFeature.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.ApproveIngredientFeature.CommandHandlers
{
    public class ApproveIngredientHandler : IRequestHandler<ApproveIngredient, Ingredient>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApproveIngredientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Ingredient> Handle(ApproveIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = await _unitOfWork.IngredientRepository.GetIngredientById(request.IngredientId);

            await _unitOfWork.IngredientRepository.UpdateIngredientStatus(ingredient, true);
            await _unitOfWork.Save();

            return ingredient;
        }
    }
}
