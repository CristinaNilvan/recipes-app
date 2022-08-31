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
            var ingredient = await _unitOfWork.IngredientRepository.GetById(request.IngredientId);

            if (ingredient == null)
            {
                return null;
            }

            await _unitOfWork.IngredientRepository.UpdateApprovedStatus(ingredient, true);
            await _unitOfWork.Save();

            return ingredient;
        }
    }
}
