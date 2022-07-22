using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Utils
    {
        public static List<Recipe> FilterByCalories(int calories, List<Recipe> recipes)
        {
            List<Recipe> filtered = new();

            foreach (Recipe recipe in recipes)
            {
                if (recipe.Calories <= calories)
                    filtered.Add(recipe);
            }

            return filtered;
        }

        public static List<Recipe> FilterByMealType(string mealType, List<Recipe> recipes)
        {
            List<Recipe> filtered = new();

            foreach (Recipe recipe in recipes)
            {
                if (recipe.Type.MealType.Equals(mealType))
                    filtered.Add(recipe);
            }

            return filtered;
        }

        public static List<Recipe> FilterByServingTime(string servingTime, List<Recipe> recipes)
        {
            List<Recipe> filtered = new();

            foreach (Recipe recipe in recipes)
            {
                if (recipe.Type.ServingTime.Equals(servingTime))
                    filtered.Add(recipe);
            }

            return filtered;
        }
    }
}
