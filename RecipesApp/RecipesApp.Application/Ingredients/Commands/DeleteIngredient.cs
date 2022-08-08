using MediatR;

namespace RecipesApp.Application.Ingredients.Commands
{
    public class DeleteIngredient : IRequest
    {
        public int IngredientId { get; set; }
    }
}
