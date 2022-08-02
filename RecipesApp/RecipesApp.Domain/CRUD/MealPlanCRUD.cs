using RecipesApp.Domain.Models;

namespace RecipesApp.Domain.CRUD
{
    public class MealPlanCRUD : BaseCRUD<MealPlan>
    {
        public static MealPlan Create()
        {
            return new MealPlan();
        }
    }
}
