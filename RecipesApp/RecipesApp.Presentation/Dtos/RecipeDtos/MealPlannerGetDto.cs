using RecipesApp.Domain.Models;

namespace RecipesApp.Presentation.Dtos.RecipeDtos
{
    public class MealPlannerGetDto
    {
        public Recipe Breakfast { get; set; }

        public Recipe Lunch { get; set; }

        public Recipe Dinner { get; set; }

        public float Calories { get; set; }

        public float Fats { get; set; }

        public float Carbs { get; set; }

        public float Proteins { get; set; }
    }
}
