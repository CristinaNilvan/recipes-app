namespace RecipesApp.Domain.Models
{
    public class MealPlan
    {
        public MealPlan()
        {
            
        }

        public Recipe? Breakfast { get; set; }
        public Recipe? Lunch { get; set; }
        public Recipe? Dinner { get; set; }
        public int Calories { get; set; }
    }
}
