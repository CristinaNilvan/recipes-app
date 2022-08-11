using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class UpdateRecipeHandler : IRequestHandler<UpdateRecipe>
    {
        private readonly IRecipeRepository _repository;

        public UpdateRecipeHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateRecipe request, CancellationToken cancellationToken)
        {
            var recipe = new Recipe(request.Name, request.Author, request.Description, request.MealType, request.ServingTime,
                request.Servings, request.Ingredients);

            await _repository.UpdateRecipe(request.RecipeId, recipe);

            return new Unit();
        }
    }
}
