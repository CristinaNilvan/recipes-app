using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class MealPlan
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
            _totalCalories++;
        }

        public void RemoveMeal(Recipe recipe)
        {
            _meals.Remove(recipe); 
            _totalCalories--;
        }
    }
}
