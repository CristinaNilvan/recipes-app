using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.FindRecipesByIngredientsFeature.Queries
{
    public class GetFoundRecipesByIngredients : IRequest<List<Recipe>>
    {
        public List<int> IngredientIds { get; set; }
    }
}