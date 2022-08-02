using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
