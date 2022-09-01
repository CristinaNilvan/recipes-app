using MediatR;

namespace RecipesApp.Application.IngredientImages.Queries
{
    public class GetIngredientImageUrlByIngredientId : IRequest<string>
    {
        public int IngredientId { get; set; }
    }
}
