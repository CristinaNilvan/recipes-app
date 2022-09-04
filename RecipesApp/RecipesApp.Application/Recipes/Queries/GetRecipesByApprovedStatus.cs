using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Queries
{
    public class GetRecipesByApprovedStatus : IRequest<List<Recipe>>
    {
        public PaginationParameters PaginationParameters { get; set; }
        public bool ApprovedStatus { get; set; }
    }
}
