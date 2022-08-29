using MediatR;
using Microsoft.AspNetCore.Http;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Commands
{
    public class AddImageToRecipe : IRequest<Recipe>
    {
        public int RecipeId { get; set; }
        public IFormFile File { get; set; }
        public string ContainerName { get; set; }
    }
}
