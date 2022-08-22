using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetRecipeByNameHandler : IRequestHandler<GetRecipeByName, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecipeByNameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Recipe> Handle(GetRecipeByName request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RecipeRepository.GetRecipeByName(request.RecipeName);
        }
    }
}
