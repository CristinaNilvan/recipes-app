using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.RecipeIngredients.Queries
{
    public class GetRecipeIngredientsByIngredientId : IRequest<List<RecipeIngredient>>
    {
        public int IngredientId { get; set; }
    }
}