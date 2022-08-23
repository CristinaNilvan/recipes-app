using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.RecipeIngredients.Queries
{
    public class GetRecipeIngredientById : IRequest<RecipeIngredient>
    {
        public int RecipeIngredientId { get; set; }
    }
}