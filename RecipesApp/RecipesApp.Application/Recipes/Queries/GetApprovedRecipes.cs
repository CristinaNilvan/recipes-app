using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Queries
{
    public class GetApprovedRecipes : IRequest<List<Recipe>>
    {
    }
}
