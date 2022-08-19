using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IMealPlanRepository
    {
        Task<MealPlan> CreateMealPlan(MealPlan mealPlan);
        Task<MealPlan> GetMealPlanById(int mealPlanId);
        Task<MealPlan> UpdateMealPlan(MealPlan newMealPlan);
        Task<MealPlan> DeleteMealPlan(int mealPlanId);
        Task<List<MealPlan>> GetAllMealPlans();
    }
}