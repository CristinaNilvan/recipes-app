using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetRecipeByIdHandler : IRequestHandler<GetRecipeById, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecipeByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Recipe> Handle(GetRecipeById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RecipeRepository.GetById(request.RecipeId);
        }
    }
}
