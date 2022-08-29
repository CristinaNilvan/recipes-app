using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class AddImageToRecipeHandler : IRequestHandler<AddImageToRecipe, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobService _blobService;

        public AddImageToRecipeHandler(IUnitOfWork unitOfWork, IBlobService blobService)
        {
            _unitOfWork = unitOfWork;
            _blobService = blobService;
        }

        public async Task<Recipe> Handle(AddImageToRecipe request, CancellationToken cancellationToken)
        {
            var recipe = await _unitOfWork.RecipeRepository.GetById(request.RecipeId);

            if (recipe == null)
            {
                return null;
            }

            var fileName = recipe.Name.Replace(" ", "_").ToLower();
            var imageUrl = await _blobService.UploadBlob(fileName, request.File, request.ContainerName);

            var recipeImage = new RecipeImage
            {
                RecipeId = request.RecipeId,
                Recipe = recipe,
                StorageImageUrl = imageUrl
            };

            await _unitOfWork.RecipeImageRepository.Create(recipeImage);
            await _unitOfWork.Save();

            return recipe;
        }
    }
}
