using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Commands
{
    public class DeleteRecipe : IRequest<Recipe>
    {
        public int RecipeId { get; set; }
    }
}
