using RecipesApp.Domain.Enums;
using RecipesApp.Presentation.Dtos.RecipeIngredientDtos;

namespace RecipesApp.Presentation.Dtos.RecipeDtos
{
    public class RecipeGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public MealType MealType { get; set; }
        public ServingTime ServingTime { get; set; }
        public float Servings { get; set; }
        public float Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
        public List<RecipeIngredientGetDto> RecipeIngredients { get; set; }
    }
}
