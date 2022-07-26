namespace RecipesApp.Domain.Models
{
    public class MealPlan
    {
        public MealPlan()
        {
            MealPlanDate = DateTime.Now;
        }

        public Recipe? Breakfast { get; set; }
        public Recipe? Lunch { get; set; }
        public Recipe? Dinner { get; set; }
        public DateTimeOffset? MealPlanDate { get; set; }
        public int Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }

        public void SetCalories()
        {
            Calories = Breakfast.Calories + Lunch.Calories + Dinner.Calories;
        }

        public void SetFats()
        {
            Fats = Breakfast.Fats + Lunch.Fats + Dinner.Fats;
        }

        public void SetCarbs()
        {
            Carbs = Breakfast.Carbs + Lunch.Carbs + Dinner.Carbs;
        }

        public void SetProteins()
        {
            Proteins = Breakfast.Proteins + Lunch.Proteins + Dinner.Proteins;
        }
    }
}
