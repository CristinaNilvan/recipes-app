using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.ApproveIngredientFeature.Commands
{
    public class ApproveIngredient : IRequest<Ingredient>
    {
        public int IngredientId { get; set; }
    }
}