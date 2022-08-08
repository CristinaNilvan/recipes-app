using MediatR;
using RecipesApp.Domain.Enums;

namespace RecipesApp.Application.Ingredients.Commands
{
    public class UpdateIngredient : IRequest
    {
        public int IngredientId { get; set; }
        public string? Name { get; set; }
        public IngredientCategory Category { get; set; }
        public int Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
    }
}
