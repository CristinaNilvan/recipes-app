﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application
{
    public interface IMealPlanRepository
    {
        void CreateMealPlan(MealPlan mealPlan);
        MealPlan GetMealPlan(int mealPlanId);
        void UpdateMealPlan(int mealPlanId, MealPlan newMealPlan);
        void DeleteMealPlan(int mealPlanId);
        List<MealPlan> GetMealPlans();
    }
}
