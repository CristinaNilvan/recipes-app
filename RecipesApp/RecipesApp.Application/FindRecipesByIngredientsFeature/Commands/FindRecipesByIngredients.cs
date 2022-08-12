using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.FindRecipesByIngredientsFeature.Commands
{
    public class FindRecipesByIngredients : IRequest<List<Recipe>>
    {
        public List<Ingredient> Ingredients { get; set; }
    }
}