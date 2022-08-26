using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IMealPlanRepository
    {
        Task Create(MealPlan mealPlan);
        Task<MealPlan> GetById(int mealPlanId);
        Task Update(MealPlan mealPlan);
        Task Delete(MealPlan mealPlan);
        Task<List<MealPlan>> GetAll();
    }
}