using MediatR;
using RecipesApp.Domain.Enums;

namespace RecipesApp.Application.Ingredients.Commands
{
    public class CreateIngredient : IRequest
    {
        public string Name { get; set; }
        public IngredientCategory Category { get; set; }
        public float Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
    }
}
