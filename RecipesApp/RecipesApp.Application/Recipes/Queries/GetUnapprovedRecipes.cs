using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Queries
{
    public class GetUnapprovedRecipes : IRequest<List<Recipe>>
    {
    }
}
