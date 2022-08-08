using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Queries
{
    public class GetAllRecipes : IRequest<List<Recipe>>
    {
    }
}
