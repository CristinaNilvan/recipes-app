namespace RecipesApp.Domain.Models
{
    public class MealPlan
    {
        public MealPlan()
        {

        }

        public MealPlan(Recipe breakfast, Recipe lunch, Recipe dinner)
        {
            Breakfast = breakfast;
            Lunch = lunch;
            Dinner = dinner;
            CalculateNutritionalValues();
        }

        public int Id { get; set; }
        public Recipe Breakfast { get; set; }
        public Recipe Lunch { get; set; }
        public Recipe Dinner { get; set; }
        public float Calories { get; set; } = 0;
        public float Fats { get; set; } = 0;
        public float Carbs { get; set; } = 0;
        public float Proteins { get; set; } = 0;

        private void CalculateNutritionalValues()
        {
            Calories = Breakfast.Calories + Lunch.Calories + Dinner.Calories;
            Fats = Breakfast.Fats + Lunch.Fats + Dinner.Fats;
            Carbs = Breakfast.Carbs + Lunch.Carbs + Dinner.Carbs;
            Proteins = Breakfast.Proteins + Lunch.Proteins + Dinner.Proteins;
        }

        public override string ToString()
        {
            return $"Breakfast: {Breakfast}\n" +
                $"Lunch: {Lunch}\n" +
                $"Dinner: {Dinner}\n" +
                $"Total calories: {Calories}";
        }
    }
}
