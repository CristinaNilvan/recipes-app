using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.RecipeIngredients.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.RecipeIngredients.QueryHandlers
{
    public class GetRecipeIngredietByQuantityAndIngredientIdHandler :
        IRequestHandler<GetRecipeIngredientByQuantityAndIngredientId, RecipeIngredient>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecipeIngredietByQuantityAndIngredientIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RecipeIngredient> Handle(GetRecipeIngredientByQuantityAndIngredientId request,
            CancellationToken cancellationToken)
        {
            return await _unitOfWork.RecipeIngredientRepository.GetRecipeIngredientByQuantityAndIngredientId(request.Quantity,
                request.IngredientId);
        }
    }
}
