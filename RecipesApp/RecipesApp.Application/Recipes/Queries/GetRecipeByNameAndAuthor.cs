using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Queries
{
    public class GetRecipeByNameAndAuthor : IRequest<Recipe>
    {
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
