namespace RecipesApp.Presentation.Dtos.RecipeDtos
{
    public class MealPlannerGetDto
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
