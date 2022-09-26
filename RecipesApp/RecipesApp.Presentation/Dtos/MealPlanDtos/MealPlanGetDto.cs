using RecipesApp.Presentation.Dtos.RecipeDtos;

namespace RecipesApp.Presentation.Dtos.MealPlanDtos
{
    public class MealPlanGetDto
    {
        public RecipeGetDto Breakfast { get; set; }

        public RecipeGetDto Lunch { get; set; }

        public RecipeGetDto Dinner { get; set; }

        public float Calories { get; set; }

        public float Fats { get; set; }

        public float Carbs { get; set; }

        public float Proteins { get; set; }
    }
}
