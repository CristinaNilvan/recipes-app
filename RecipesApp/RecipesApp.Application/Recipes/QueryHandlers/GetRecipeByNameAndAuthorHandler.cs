using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.QueryHandlers
{
    public class GetRecipeByNameAndAuthorHandler : IRequestHandler<GetRecipeByNameAndAuthor, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecipeByNameAndAuthorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Recipe> Handle(GetRecipeByNameAndAuthor request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RecipeRepository.GetByNameAndAuthor(request.Name, request.Author);
        }
    }
}
