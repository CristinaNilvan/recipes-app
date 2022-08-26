using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.RecipeIngredients.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.RecipeIngredients.QueryHandlers
{
    public class GetRecipeIngredientsByIngredientIdHandler :
        IRequestHandler<GetRecipeIngredientsByIngredientId, List<RecipeIngredient>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecipeIngredientsByIngredientIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RecipeIngredient>> Handle(GetRecipeIngredientsByIngredientId request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RecipeIngredientRepository.GetByIngredientId(request.IngredientId);
        }
    }
}
