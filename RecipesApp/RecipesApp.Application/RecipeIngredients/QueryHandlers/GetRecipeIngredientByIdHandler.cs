using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.RecipeIngredients.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.RecipeIngredients.QueryHandlers
{
    public class GetRecipeIngredientByIdHandler : IRequestHandler<GetRecipeIngredientById, RecipeIngredient>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecipeIngredientByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RecipeIngredient> Handle(GetRecipeIngredientById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RecipeIngredientRepository.GetById(request.RecipeIngredientId);
        }
    }
}
