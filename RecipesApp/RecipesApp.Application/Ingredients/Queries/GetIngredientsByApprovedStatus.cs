using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.Queries
{
    public class GetIngredientsByApprovedStatus : IRequest<List<Ingredient>>
    {
        public bool ApprovedStatus { get; set; }
    }
}
