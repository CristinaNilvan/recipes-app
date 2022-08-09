using MediatR;

namespace RecipesApp.Application.ApproveIngredientFeature.Commands
{
    public class ApproveIngredient : IRequest
    {
        public int IngredientId { get; set; }
    }
}