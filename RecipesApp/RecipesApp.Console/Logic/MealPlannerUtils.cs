﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Console.Logic
{
    internal class MealPlannerUtils
    {
        public static List<Recipe> FilterByCalories(int calories, List<Recipe> recipes)
        {
            var filtered = new List<Recipe>();

            foreach (Recipe recipe in recipes)
            {
                if (recipe.Calories <= calories)
                {
                    filtered.Add(recipe);
                }
            }

            return filtered;
        }

        public static List<Recipe> FilterByMealType(MealType mealType, List<Recipe> recipes)
        {
            var filtered = new List<Recipe>();

            foreach (Recipe recipe in recipes)
            {
                if (recipe.Type.MealType == mealType)
                {
                    filtered.Add(recipe);
                }
            }

            return filtered;
        }

        public static List<Recipe> FilterByServingTime(ServingTime servingTime, List<Recipe> recipes)
        {
            var filtered = new List<Recipe>();

            foreach (Recipe recipe in recipes)
            {
                if (recipe.Type.ServingTime == servingTime)
                {
                    filtered.Add(recipe);
                }
            }

            return filtered;
        }
    }
}