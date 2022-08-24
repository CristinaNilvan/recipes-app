using MediatR;

namespace RecipesApp.Application.RecipeIngredients.Queries
{
    public class GetRecipeIngredietQuantitiesByIngredientId : IRequest<List<float>>
    {
        public int IngredientId { get; set; }
    }
}
