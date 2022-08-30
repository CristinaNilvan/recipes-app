using RecipesApp.Domain.Enums;
using RecipesApp.Presentation.Dtos.IngredientImageDtos;

namespace RecipesApp.Presentation.Dtos.IngredientDtos
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
        public IngredientImageGetDto IngredientImage { get; set; }
    }
}