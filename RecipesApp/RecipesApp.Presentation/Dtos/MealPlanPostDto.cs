using RecipesApp.Domain.Enums;

namespace RecipesApp.Presentation.Dtos
{
    public class MealPlanPostDto
    {
        public MealType MealType { get; set; }
        public float Calories { get; set; }
    }
}
