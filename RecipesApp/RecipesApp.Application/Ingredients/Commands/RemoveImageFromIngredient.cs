using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.Commands
{
    public class RemoveImageFromIngredient : IRequest<Ingredient>
    {
        public int IngredientId { get; set; }
        public string ContainerName { get; set; }
    }
}
