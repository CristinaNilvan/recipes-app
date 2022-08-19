using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure.InMemoryRepositories
{
    public class InMemoryMealPlanRepository : IMealPlanRepository
    {
        private List<MealPlan> _mealPlans = new();

        public async Task<MealPlan> CreateMealPlan(MealPlan mealPlan)
        {
            mealPlan.Id = _mealPlans.Count > 0 ? _mealPlans.ElementAt(_mealPlans.Count - 1).Id + 1 : 1;
            _mealPlans.Add(mealPlan);

            return mealPlan;
        }

        public async Task<MealPlan> DeleteMealPlan(int mealPlanId)
        {
            var mealPlan = _mealPlans.FirstOrDefault(x => x.Id == mealPlanId);
            _mealPlans.Remove(mealPlan);

            return mealPlan;
        }

        public async Task<MealPlan> GetMealPlanById(int mealPlanId)
        {
            return _mealPlans.FirstOrDefault(x => x.Id == mealPlanId);
        }

        public async Task<List<MealPlan>> GetAllMealPlans()
        {
            return _mealPlans;
        }

        public async Task<MealPlan> UpdateMealPlan(MealPlan newMealPlan)
        {
            var mealPlan = _mealPlans.FirstOrDefault(x => x.Id == newMealPlan.Id);
            var index = _mealPlans.IndexOf(mealPlan);
            mealPlan.Id = newMealPlan.Id;
            _mealPlans[index] = newMealPlan;

            return mealPlan;
        }
    }
}
