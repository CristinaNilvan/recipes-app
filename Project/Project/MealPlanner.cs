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

        public void GenerateMealPlan(string mealType, double calories)
        {

        }
    }
}
