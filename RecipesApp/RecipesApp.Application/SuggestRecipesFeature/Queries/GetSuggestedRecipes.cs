using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.SuggestRecipesFeature.Queries
{
    public class GetSuggestedRecipes : IRequest<List<Recipe>>
    {
        public PaginationParameters PaginationParameters { get; set; }
        public string IngredientName { get; set; }
        public float IngredientQuantity { get; set; }
    }
}