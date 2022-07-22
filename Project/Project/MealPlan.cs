using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class MealPlan
    {
        private List<Recipe>? _recipes;
        private double calories;
        
        public MealPlan() 
        {
            _recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe) => _recipes.Add(recipe); // + add calories
        public void RemoveRecipe(Recipe recipe) => _recipes.Remove(recipe); // + remove calories
    }
}
