using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.RecipeIngredients.Commands
{
    public class CreateRecipeIngredient : IRequest<RecipeIngredient>
    {
        public float Quantity { get; set; }
        public int IngredientId { get; set; }
    }
}
