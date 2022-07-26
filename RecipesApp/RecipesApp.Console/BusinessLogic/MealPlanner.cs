﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Models;

namespace RecipesApp.Console.BusinessLogic
{
    internal class MealPlanner
    {
        private List<Recipe>? _allRecipes;

        public MealPlanner(List<Recipe> allRecipes)
        {
            _allRecipes.AddRange(allRecipes);
        }

        public MealPlan GenerateMealPlan(MealType mealType, int calories)
        {
            int averageCalories = calories / 3;
            var filteredRecipes = new List<Recipe>();

            filteredRecipes.AddRange(Utils.FilterByCalories(averageCalories, _allRecipes));
            filteredRecipes.AddRange(Utils.FilterByMealType(mealType, _allRecipes));

            List<Recipe> breakfastRecipes = Utils.FilterByServingTime(ServingTime.Breakfast, filteredRecipes);
            List<Recipe> lunchRecipes = Utils.FilterByServingTime(ServingTime.Lunch, filteredRecipes);
            List<Recipe> dinnerRecipes = Utils.FilterByServingTime(ServingTime.Dinner, filteredRecipes);

            var random = new Random();
            var mealPlan = new MealPlan();

            mealPlan.Breakfast = breakfastRecipes.ElementAt(random.Next(0, breakfastRecipes.Count));
            mealPlan.Lunch = lunchRecipes.ElementAt(random.Next(0, lunchRecipes.Count));
            mealPlan.Dinner = dinnerRecipes.ElementAt(random.Next(0, dinnerRecipes.Count));

            return mealPlan;
        }
    }
}