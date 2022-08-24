using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.RecipeIngredients.Queries;

namespace RecipesApp.Application.RecipeIngredients.QueryHandlers
{
    public class GetRecipeIngredietQuantitiesByIngredientIdHandler : 
        IRequestHandler<GetRecipeIngredietQuantitiesByIngredientId, List<float>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecipeIngredietQuantitiesByIngredientIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<float>> Handle(GetRecipeIngredietQuantitiesByIngredientId request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RecipeIngredientRepository.GetRecipeIngredietQuantitiesByIngredientId(request.IngredientId);
        }
    }
}
