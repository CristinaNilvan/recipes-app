using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Queries
{
    public class GetRecipesByIngredients : IRequest<List<Recipe>>
    {
        public List<Ingredient> Ingredients { get; set; }
    }
}