using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IMealPlanRepository
    {
        Task CreateMealPlan(MealPlan mealPlan);
        Task<MealPlan> GetMealPlanById(int mealPlanId);
        Task UpdateMealPlan(MealPlan mealPlan);
        Task DeleteMealPlan(MealPlan mealPlan);
        Task<List<MealPlan>> GetAllMealPlans();
    }
}