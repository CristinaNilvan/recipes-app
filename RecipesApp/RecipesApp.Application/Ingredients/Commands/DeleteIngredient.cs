using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.Commands
{
    public class DeleteIngredient : IRequest<Ingredient>
    {
        public int IngredientId { get; set; }
    }
}
