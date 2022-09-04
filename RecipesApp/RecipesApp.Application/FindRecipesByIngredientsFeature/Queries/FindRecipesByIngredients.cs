using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.FindRecipesByIngredientsFeature.Queries
{
    public class FindRecipesByIngredients : IRequest<List<Recipe>>
    {
        public PaginationParameters PaginationParameters { get; set; }
        public List<int> IngredientIds { get; set; }
    }
}