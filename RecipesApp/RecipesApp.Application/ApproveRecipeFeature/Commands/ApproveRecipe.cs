using MediatR;

namespace RecipesApp.Application.ApproveRecipeFeature.Commands
{
    public class ApproveRecipe : IRequest
    {
        public int RecipeId { get; set; }
    }
}
