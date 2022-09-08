using MediatR;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Commands
{
    public class UpdateRecipe : IRequest<Recipe>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public MealType? MealType { get; set; }
        public ServingTime? ServingTime { get; set; }
        public float? Servings { get; set; }

        // to delete
        public List<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
