﻿namespace RecipesApp.Domain.Models
{
    public class MealPlan
    {
        public MealPlan()
        {
            MealPlanDate = DateTime.UtcNow;
        }

        public Recipe? Breakfast { get; set; }
        public Recipe? Lunch { get; set; }
        public Recipe? Dinner { get; set; }
        public DateTimeOffset? MealPlanDate { get; set; }
        public int Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }

        public void CalculateCalories()
        {
            Calories = Breakfast.Calories + Lunch.Calories + Dinner.Calories;
        }

        public void CalculateFats()
        {
            Fats = Breakfast.Fats + Lunch.Fats + Dinner.Fats;
        }

        public void CalculateCarbs()
        {
            Carbs = Breakfast.Carbs + Lunch.Carbs + Dinner.Carbs;
        }

        public void CalculateProteins()
        {
            Proteins = Breakfast.Proteins + Lunch.Proteins + Dinner.Proteins;
        }
    }
}
