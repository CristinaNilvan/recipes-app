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

        public async Task CreateMealPlan(MealPlan mealPlan)
        {
            await _dataContext.MealPlans.AddAsync(mealPlan);
        }

        public async Task DeleteMealPlan(MealPlan mealPlan)
        {
            _dataContext.MealPlans.Remove(mealPlan);
        }

        public async Task<List<MealPlan>> GetAllMealPlans()
        {
            return await _dataContext.MealPlans.ToListAsync();
        }

        public async Task<MealPlan> GetMealPlanById(int mealPlanId)
        {
            return await _dataContext.MealPlans.SingleOrDefaultAsync(x => x.Id == mealPlanId);
        }

        public async Task UpdateMealPlan(MealPlan mealPlan)
        {
            _dataContext.MealPlans.Update(mealPlan);
        }
    }
}
