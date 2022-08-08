using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.Queries
{
    public class GetIngredientById : IRequest<Ingredient>
    {
        public int IngredientId { get; set; }
    }
}
