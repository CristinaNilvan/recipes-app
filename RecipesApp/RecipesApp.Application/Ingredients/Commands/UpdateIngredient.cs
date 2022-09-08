using MediatR;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.Commands
{
    public class UpdateIngredient : IRequest<Ingredient>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IngredientCategory? Category { get; set; }
        public float? Calories { get; set; }
        public float? Fats { get; set; }
        public float? Carbs { get; set; }
        public float? Proteins { get; set; }
    }
}
