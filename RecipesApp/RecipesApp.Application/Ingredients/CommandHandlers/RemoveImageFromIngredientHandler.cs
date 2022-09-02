using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Abstractions.Services;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class RemoveImageFromIngredientHandler : IRequestHandler<RemoveImageFromIngredient, Ingredient>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _blobService;

        public RemoveImageFromIngredientHandler(IUnitOfWork unitOfWork, IImageStorageService blobService)
        {
            _unitOfWork = unitOfWork;
            _blobService = blobService;
        }

        public async Task<Ingredient> Handle(RemoveImageFromIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = await _unitOfWork.IngredientRepository.GetById(request.IngredientId);
            var ingredientImage = await _unitOfWork.IngredientImageRepository.GetByIngredientId(request.IngredientId);

            if (ingredient == null || ingredientImage == null)
            {
                return null;
            }

            var fileName = ingredient.Name.Replace(" ", "_").ToLower();

            await _blobService.DeleteImage(fileName, request.ContainerName);
            await _unitOfWork.IngredientImageRepository.Delete(ingredientImage);
            await _unitOfWork.Save();

            return ingredient;
        }
    }
}
