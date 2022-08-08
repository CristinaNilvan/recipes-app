using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Queries
{
    internal class GetApprovedRecipes : IRequest<List<Recipe>>
    {
    }
}
