using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.RecipeImages.Queries;

namespace RecipesApp.Application.RecipeImages.QueryHandlers
{
    public class GetRecipeImageUrlByRecipeIdHandler : IRequestHandler<GetRecipeImageUrlByRecipeId, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecipeImageUrlByRecipeIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetRecipeImageUrlByRecipeId request, CancellationToken cancellationToken)
        {
            var recipeImage = await _unitOfWork.RecipeImageRepository.GetByRecipeId(request.RecipeId);

            if (recipeImage == null)
            {
                return null;
            }

            return recipeImage.StorageImageUrl;
        }
    }
}
