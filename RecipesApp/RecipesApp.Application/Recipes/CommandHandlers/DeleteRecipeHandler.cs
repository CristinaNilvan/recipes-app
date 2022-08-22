using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class DeleteRecipeHandler : IRequestHandler<DeleteRecipe, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRecipeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Recipe> Handle(DeleteRecipe request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RecipeRepository.DeleteRecipe(request.RecipeId);
        }
    }
}
