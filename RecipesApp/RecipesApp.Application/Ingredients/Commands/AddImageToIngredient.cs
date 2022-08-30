using MediatR;
using Microsoft.AspNetCore.Http;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.Commands
{
    public class AddImageToIngredient : IRequest<Ingredient>
    {
        public int IngredientId { get; set; }
        public IFormFile File { get; set; }
        public string ContainerName { get; set; }
    }
}
