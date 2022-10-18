using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Commands
{
    public class AddRecipeIngredientsToRecipe : IRequest<Recipe>
    {
        public int RecipeId { get; set; }
        public List<int> RecipeIngredientIds { get; set; }
    }
}