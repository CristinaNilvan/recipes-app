using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Abstractions.Services;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class AddImageToRecipeHandler : IRequestHandler<AddImageToRecipe, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public AddImageToRecipeHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<Recipe> Handle(AddImageToRecipe request, CancellationToken cancellationToken)
        {
            var recipe = await _unitOfWork.RecipeRepository.GetById(request.RecipeId);

            if (recipe == null)
            {
                return null;
            }

            var recipeNameAndAuthor = recipe.Name + " " + recipe.Author;
            var fileName = recipeNameAndAuthor.Replace(" ", "_").ToLower();
            var imageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

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
