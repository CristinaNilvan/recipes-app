using MediatR;

namespace RecipesApp.Application.Recipes.Commands
{
    public class DeleteRecipe : IRequest
    {
        public int RecipeId { get; set; }
    }
}
