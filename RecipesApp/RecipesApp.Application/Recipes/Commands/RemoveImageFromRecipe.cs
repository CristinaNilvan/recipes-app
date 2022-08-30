using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Commands
{
    public class RemoveImageFromRecipe : IRequest<Recipe>
    {
        public int RecipeId { get; set; }
        public string ContainerName { get; set; }
    }
}
