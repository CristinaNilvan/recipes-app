using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions.Repositories;
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

        public async Task Create(MealPlan mealPlan)
        {
            await _dataContext
                .MealPlans
                .AddAsync(mealPlan);
        }

        public async Task Delete(MealPlan mealPlan)
        {
            _dataContext
                .MealPlans
                .Remove(mealPlan);
        }

        public async Task<MealPlan> GetById(int mealPlanId)
        {
            return await _dataContext
                .MealPlans
                .SingleOrDefaultAsync(x => x.Id == mealPlanId);
        }

        public async Task Update(MealPlan mealPlan)
        {
            _dataContext
                .MealPlans
                .Update(mealPlan);
        }
    }
}
