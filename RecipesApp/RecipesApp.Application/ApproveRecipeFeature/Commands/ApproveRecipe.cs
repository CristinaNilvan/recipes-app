using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.ApproveRecipeFeature.Commands
{
    public class ApproveRecipe : IRequest<Recipe>
    {
        public int RecipeId { get; set; }
    }
}
