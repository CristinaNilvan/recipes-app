using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Abstractions.Services;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class AddImageToIngredientHandler : IRequestHandler<AddImageToIngredient, Ingredient>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public AddImageToIngredientHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<Ingredient> Handle(AddImageToIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = await _unitOfWork.IngredientRepository.GetById(request.IngredientId);

            if (ingredient == null)
            {
                return null;
            }

            var fileName = ingredient.Name.Replace(" ", "_").ToLower();
            var imageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            var ingredientImage = new IngredientImage
            {
                IngredientId = request.IngredientId,
                Ingredient = ingredient,
                StorageImageUrl = imageUrl
            };

            await _unitOfWork.IngredientImageRepository.Create(ingredientImage);
            await _unitOfWork.Save();

            return ingredient;
        }
    }
}
