using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IMealPlanRepository
    {
        void CreateMealPlan(MealPlan mealPlan);
        MealPlan GetMealPlanById(int mealPlanId);
        void UpdateMealPlan(int mealPlanId, MealPlan newMealPlan);
        void DeleteMealPlan(int mealPlanId);
        List<MealPlan> GetAllMealPlans();
    }
}
