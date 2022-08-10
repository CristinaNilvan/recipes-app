using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class DeleteRecipeHandler : IRequestHandler<DeleteRecipe>
    {
        private readonly IRecipeRepository _repository;

        public DeleteRecipeHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteRecipe request, CancellationToken cancellationToken)
        {
            await _repository.DeleteRecipe(request.RecipeId);

            return new Unit();
        }
    }
}
