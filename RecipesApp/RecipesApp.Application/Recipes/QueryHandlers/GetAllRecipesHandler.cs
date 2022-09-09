using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetAllRecipesHandler : IRequestHandler<GetAllRecipes, List<Recipe>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRecipesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Recipe>> Handle(GetAllRecipes request, CancellationToken cancellationToken)
        {
            var recipes = (await _unitOfWork.RecipeRepository.GetAll(request.PaginationParameters)).ToList();

            if (recipes.Count == 0)
            {
                return null;
            }

            return recipes;
        }
    }
}
