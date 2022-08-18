using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class DeleteIngredientHandler : IRequestHandler<DeleteIngredient, Ingredient>
    {
        private readonly DataContext _dataContext;

        public DeleteIngredientHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Ingredient> Handle(DeleteIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = await _dataContext.Ingredients.SingleOrDefaultAsync(x => x.Id == request.IngredientId);

            if (ingredient == null)
            {
                return null;
            }

            _dataContext.Ingredients.Remove(ingredient);
            await _dataContext.SaveChangesAsync();

            return ingredient;
        }
    }
}
