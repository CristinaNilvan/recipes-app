using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class UpdateIngredientHandler : IRequestHandler<UpdateIngredient, Ingredient>
    {
        private readonly DataContext _dataContext;

        public UpdateIngredientHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Ingredient> Handle(UpdateIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient(request.IngredientId, request.Name, request.Category, request.Calories,
                request.Fats, request.Carbs, request.Proteins);

            if (ingredient == null)
            {
                return null;
            }

            _dataContext.Ingredients.Update(ingredient);
            await _dataContext.SaveChangesAsync();

            return ingredient;
        }
    }
}
