using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Queries
{
    public class GetRecipesByName : IRequest<List<Recipe>>
    {
        public PaginationParameters PaginationParameters { get; set; }
        public string RecipeName { get; set; }
    }
}