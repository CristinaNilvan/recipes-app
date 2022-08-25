using RecipesApp.Domain.Models;

namespace RecipesApp.Presentation.Dtos
{
    public class MealPlanGetDto
    {
        public int Id { get; set; }

        public Recipe Breakfast { get; set; }

        public Recipe Lunch { get; set; }

        public Recipe Dinner { get; set; }

        public float Calories { get; set; }

        public float Fats { get; set; }

        public float Carbs { get; set; }

        public float Proteins { get; set; }
    }
}
