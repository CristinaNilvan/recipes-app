namespace RecipesApp.Domain.Models
{
    public class MealPlan
    {
        private List<Recipe>? _meals;
        private int _totalCalories;

        public MealPlan()
        {
            _meals = new List<Recipe>();
            _totalCalories = 0;
        }

        public void AddMeal(Recipe recipe)
        {
            _meals.Add(recipe);
            _totalCalories += recipe.Calories;
        }
    }
}
