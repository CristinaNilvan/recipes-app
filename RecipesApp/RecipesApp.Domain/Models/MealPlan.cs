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
        public int Calories
        {
            get => Calories;

            set => Calories = Breakfast.Calories + Lunch.Calories + Dinner.Calories;
        }
        public float Fats
        {
            get => Fats;

            set => Fats = Breakfast.Fats + Lunch.Fats + Dinner.Fats;
        }
        public float Carbs
        {
            get => Carbs;

            set => Carbs = Breakfast.Carbs + Lunch.Carbs + Dinner.Carbs;
        }
        public float Proteins
        {
            get => Proteins;

            set => Proteins = Breakfast.Proteins + Lunch.Proteins + Dinner.Proteins;
        }
    }
}
