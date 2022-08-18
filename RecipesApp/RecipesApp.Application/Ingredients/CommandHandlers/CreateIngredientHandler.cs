using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class CreateIngredientHandler : IRequestHandler<CreateIngredient, Ingredient>
    {
        private readonly DataContext _dataContext;

        public CreateIngredientHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Ingredient> Handle(CreateIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient(request.Name, request.Category, request.Calories, request.Fats, request.Carbs,
                request.Proteins);

            _dataContext.Ingredients.Add(ingredient);
            await _dataContext.SaveChangesAsync();

            return ingredient;
        }
    }
}
