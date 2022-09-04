using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions.Repositories
{
    public interface IMealPlanRepository
    {
        Task Create(MealPlan mealPlan);
        Task<MealPlan> GetById(int mealPlanId);
        Task Update(MealPlan mealPlan);
        Task Delete(MealPlan mealPlan);
    }
}