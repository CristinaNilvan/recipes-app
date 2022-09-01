using MediatR;

namespace RecipesApp.Application.RecipeImages.Queries
{
    public class GetRecipeImageUrlByRecipeId : IRequest<string>
    {
        public int RecipeId { get; set; }
    }
}
