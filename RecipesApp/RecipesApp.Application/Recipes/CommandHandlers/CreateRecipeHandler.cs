using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class CreateRecipeHandler : IRequestHandler<CreateRecipe>
    {
        private readonly IRecipeRepository _repository;

        public CreateRecipeHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateRecipe request, CancellationToken cancellationToken)
        {
            var recipe = new Recipe(request.Name, request.Author, request.Description, request.MealType, request.ServingTime,
                request.Ingredients);

            await _repository.CreateRecipe(recipe);

            return new Unit();
        }
    }
}
