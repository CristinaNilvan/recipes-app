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
        private int calories;
        
        public MealPlan() 
        {
            _meals = new List<Recipe>();
        }

        public void AddMeal(Recipe recipe) => _meals.Add(recipe); // + add calories
        public void RemoveMeal(Recipe recipe) => _meals.Remove(recipe); // + remove calories
    }
}
