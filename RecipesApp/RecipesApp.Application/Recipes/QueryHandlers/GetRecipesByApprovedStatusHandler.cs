using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetRecipesByApprovedStatusHandler : IRequestHandler<GetRecipesByApprovedStatus, List<Recipe>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecipesByApprovedStatusHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Recipe>> Handle(GetRecipesByApprovedStatus request, CancellationToken cancellationToken)
        {
            var recipes = (await _unitOfWork
                .RecipeRepository
                .GetByApprovedStatusWithPagination(request.PaginationParameters, request.ApprovedStatus))
                .ToList();

            if (recipes.Count == 0)
            {
                return null;
            }

            return recipes;
        }
    }
}
