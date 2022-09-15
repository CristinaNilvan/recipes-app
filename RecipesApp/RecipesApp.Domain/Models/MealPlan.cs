namespace RecipesApp.Domain.Models
{
    public class MealPlan
    {
        public MealPlan()
        {

        }

        public MealPlan(Recipe breakfast, Recipe lunch, Recipe dinner, float calories, float fats, float carbs, float proteins)
        {
            Breakfast = breakfast;
            Lunch = lunch;
            Dinner = dinner;
            Calories = calories;
            Fats = fats;
            Carbs = carbs;
            Proteins = proteins;
        }

        public MealPlan(Recipe breakfast, Recipe lunch, Recipe dinner)
        {
            Breakfast = breakfast;
            Lunch = lunch;
            Dinner = dinner;
        }

        public int Id { get; set; }

        public Recipe Breakfast { get; set; }

        public Recipe Lunch { get; set; }

        public Recipe Dinner { get; set; }

        public float Calories { get; set; }

        public float Fats { get; set; }

        public float Carbs { get; set; }

        public float Proteins { get; set; }

        public override string ToString()
        {
            return $"Breakfast: {Breakfast}\n" +
                $"Lunch: {Lunch}\n" +
                $"Dinner: {Dinner}\n" +
                $"Total calories: {Calories}";
        }
    }
}
