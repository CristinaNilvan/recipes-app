using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.Queries
{
    public class GetAllIngredients : IRequest<List<Ingredient>>
    {
    }
}
