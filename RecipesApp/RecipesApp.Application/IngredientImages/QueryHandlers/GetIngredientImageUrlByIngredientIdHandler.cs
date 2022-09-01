using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.IngredientImages.Queries;

namespace RecipesApp.Application.IngredientImages.QueryHandlers
{
    public class GetIngredientImageUrlByIngredientIdHandler : IRequestHandler<GetIngredientImageUrlByIngredientId, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetIngredientImageUrlByIngredientIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetIngredientImageUrlByIngredientId request, CancellationToken cancellationToken)
        {
            var ingredientImage = await _unitOfWork.IngredientImageRepository.GetByIngredientId(request.IngredientId);

            if (ingredientImage == null)
            {
                return null;
            }

            return ingredientImage.StorageImageUrl;
        }
    }
}
