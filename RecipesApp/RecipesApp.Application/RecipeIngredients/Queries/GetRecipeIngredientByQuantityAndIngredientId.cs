using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.RecipeIngredients.Queries
{
    // to be removed??
    public class GetRecipeIngredientByQuantityAndIngredientId : IRequest<RecipeIngredient>
    {
        public float Quantity { get; set; }
        public int IngredientId { get; set; }
    }
}
