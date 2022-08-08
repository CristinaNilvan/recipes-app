using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Queries
{
    public class GetRecipeByName : IRequest<Recipe>
    {
        public string RecipeName { get; set; }
    }
}
