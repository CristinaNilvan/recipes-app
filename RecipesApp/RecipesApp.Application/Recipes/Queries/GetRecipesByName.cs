using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Queries
{
    public class GetRecipesByName : IRequest<List<Recipe>>
    {
        public string RecipeName { get; set; }
    }
}