using RecipesApp.Domain.Enums;

namespace RecipesApp.Presentation.Dtos
{
    public class IngredientGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IngredientCategory Category { get; set; }
        public float Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
    }
}