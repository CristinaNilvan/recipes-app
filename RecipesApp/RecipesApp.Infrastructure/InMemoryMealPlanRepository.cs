using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Application;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure
{
    internal class InMemoryMealPlanRepository : IMealPlanRepository
    {
        private List<MealPlan> _mealPlans = new();

        public List<MealPlan> MealPlans => _mealPlans;

        public void CreateMealPlan(MealPlan mealPlan)
        {
            mealPlan.Id = _mealPlans.Count + 1;
            _mealPlans.Add(mealPlan);
        }

        public void DeleteMealPlan(int mealPlanId)
        {
            var mealPlan = _mealPlans.FirstOrDefault(x => x.Id == mealPlanId);
            _mealPlans.Remove(mealPlan);
        }

        public MealPlan GetMealPlan(int mealPlanId)
        {
            return _mealPlans.FirstOrDefault(x => x.Id == mealPlanId);
        }

        public IEnumerable<MealPlan> GetMealPlans()
        {
            return _mealPlans;
        }

        public void UpdateMealPlan(int mealPlanId, MealPlan newMealPlan)
        {
            var mealPlan = _mealPlans.FirstOrDefault(x => x.Id == mealPlanId);
            var index = _mealPlans.IndexOf(mealPlan);
            _mealPlans[index] = newMealPlan;
        }
    }
}
