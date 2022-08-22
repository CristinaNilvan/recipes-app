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
            return await _unitOfWork.IngredientRepository.DeleteIngredient(request.IngredientId);
        }
    }
}
