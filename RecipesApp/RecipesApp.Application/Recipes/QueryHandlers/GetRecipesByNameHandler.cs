using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetRecipesByNameHandler : IRequestHandler<GetRecipesByName, List<Recipe>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecipesByNameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Recipe>> Handle(GetRecipesByName request, CancellationToken cancellationToken)
        {
            var recipes = (await _unitOfWork
                .RecipeRepository
                .GetByName(request.PaginationParameters, request.RecipeName))
                .ToList();

            if (recipes.Count == 0)
            {
                return null;
            }

            return recipes;
        }
    }
}
