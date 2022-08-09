using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Queries
{
    public class GetRecipesByApprovedStatus : IRequest<List<Recipe>>
    {
        public bool ApprovedStatus { get; set; }
    }
}
