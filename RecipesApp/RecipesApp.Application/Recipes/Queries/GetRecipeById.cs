using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Queries
{
    public class GetRecipeById : IRequest<Recipe>
    {
        public int RecipeId { get; set; }
    }
}
