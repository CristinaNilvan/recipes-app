using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Application;
using RecipesApp.Domain.Models;

namespace RecipesApp.Assignments.CreationalPatterns
{
    public class SingleInMemoryMealPlanRepository : IMealPlanRepository
    {
        private static SingleInMemoryMealPlanRepository _mealPlanRepository;
        private List<MealPlan> _mealPlans = new();

        private SingleInMemoryMealPlanRepository()
        {
            Console.WriteLine("Constructor call");
        }

        public static SingleInMemoryMealPlanRepository Instance
        {
            get
            {
                if (_mealPlanRepository == null)
                    _mealPlanRepository = new SingleInMemoryMealPlanRepository();

                return _mealPlanRepository;
            }

            private set { }
        }

        public List<MealPlan> MealPlans => _mealPlans;

        public void CreateMealPlan(MealPlan mealPlan)
        {
            mealPlan.Id = _mealPlans.Count + 1;
            _mealPlans.Add(mealPlan);
        }

        public void DeleteMealPlan(int mealPlanId)
        {
            var mealPlan = _mealPlans.FirstOrDefault(x => x.Id == mealPlanId);
            _mealPlans.Remove(mealPlan);
        }

        public MealPlan GetMealPlan(int mealPlanId)
        {
            return _mealPlans.FirstOrDefault(x => x.Id == mealPlanId);
        }

        public List<MealPlan> GetMealPlans()
        {
            return _mealPlans;
        }

        public void UpdateMealPlan(int mealPlanId, MealPlan newMealPlan)
        {
            var mealPlan = _mealPlans.FirstOrDefault(x => x.Id == mealPlanId);
            var index = _mealPlans.IndexOf(mealPlan);
            mealPlan.Id = mealPlanId;
            _mealPlans[index] = newMealPlan;
        }
    }
}
