using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure.Context;

namespace RecipesApp.Infrastructure.Repositories
{
    public class MealPlanRepository : IMealPlanRepository
    {
        private readonly DataContext _dataContext;

        public MealPlanRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<MealPlan> CreateMealPlan(MealPlan mealPlan)
        {
            _dataContext.MealPlans.Add(mealPlan);
            await _dataContext.SaveChangesAsync();

            return mealPlan;
        }

        public async Task<MealPlan> DeleteMealPlan(int mealPlanId)
        {
            var mealPlan = await _dataContext.MealPlans.SingleOrDefaultAsync(x => x.Id == mealPlanId);

            if (mealPlan == null)
            {
                return null;
            }

            _dataContext.MealPlans.Remove(mealPlan);
            await _dataContext.SaveChangesAsync();

            return mealPlan;
        }

        public async Task<List<MealPlan>> GetAllMealPlans()
        {
            return await _dataContext.MealPlans.ToListAsync();
        }

        public async Task<MealPlan> GetMealPlanById(int mealPlanId)
        {
            return await _dataContext.MealPlans.SingleOrDefaultAsync(x => x.Id == mealPlanId);
        }

        public Task UpdateMealPlan(int mealPlanId, MealPlan newMealPlan)
        {
            throw new NotImplementedException();
        }

        public async Task<MealPlan> UpdateMealPlan(MealPlan newMealPlan)
        {
            if (newMealPlan == null)
            {
                return null;
            }

            _dataContext.MealPlans.Update(newMealPlan);
            await _dataContext.SaveChangesAsync();

            return newMealPlan;
        }
    }
}
