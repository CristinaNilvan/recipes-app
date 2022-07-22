using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class MealPlanner
    {
        private List<Recipe>? _allRecipes;

        public MealPlanner(List<Recipe> allRecipes)
        {
            _allRecipes = allRecipes;
        }

        public MealPlan GenerateMealPlan(string mealType, int calories)
        {
            int averageCalories = calories / 3;
            List<Recipe> filteredRecipes = new ();

            foreach (Recipe recipe in _allRecipes)
            {
                if (recipe.Type.MealType.Equals(mealType) && recipe.Calories <= averageCalories) 
                    filteredRecipes.Add(recipe);
            }

            List<Recipe> breakfastRecipes = Utils.FilterByServingTime("breakfast", filteredRecipes);
            List<Recipe> lunchRecipes = Utils.FilterByServingTime("lunch", filteredRecipes);
            List<Recipe> dinnerRecipes = Utils.FilterByServingTime("dinner", filteredRecipes);

            Random random = new();
            MealPlan mealPlan = new();

            mealPlan.AddMeal(breakfastRecipes.ElementAt(random.Next(0, breakfastRecipes.Count)));
            mealPlan.AddMeal(lunchRecipes.ElementAt(random.Next(0, lunchRecipes.Count)));
            mealPlan.AddMeal(dinnerRecipes.ElementAt(random.Next(0, dinnerRecipes.Count)));

            return mealPlan;
        }
    }
}
