using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.Queries
{
    public class GetIngredientsByApprovedStatus : IRequest<List<Ingredient>>
    {
        public PaginationParameters PaginationParameters { get; set; }
        public bool ApprovedStatus { get; set; }
    }
}
