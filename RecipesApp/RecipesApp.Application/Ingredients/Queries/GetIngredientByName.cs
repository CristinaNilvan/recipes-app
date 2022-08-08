using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.Queries
{
    public class GetIngredientByName : IRequest<Ingredient>
    {
        public string IngredientName { get; set; } 
    }
}
