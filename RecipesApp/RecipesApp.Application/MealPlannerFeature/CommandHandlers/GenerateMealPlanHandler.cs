using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.MealPlannerFeature.Commands;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.MealPlannerFeature.CommandHandlers
{
    public class GenerateMealPlanHandler : IRequestHandler<GenerateMealPlan, MealPlan>
    {
        private readonly IMealPlanRepository _mealPlanRepository;

        private List<Recipe> _allRecipes;
        private List<Recipe> _breakfastRecipes;
        private List<Recipe> _lunchRecipes;
        private List<Recipe> _dinnerRecipes;

        public GenerateMealPlanHandler(IMealPlanRepository mealPlanRepository)
        {
            _mealPlanRepository = mealPlanRepository;
        }

        public Task<MealPlan> Handle(GenerateMealPlan request, CancellationToken cancellationToken)
        {
            var mealPlan = GenerateMealPlan(request.MealType, request.Calories, request.Recipes);
            _mealPlanRepository.CreateMealPlan(mealPlan);

            return Task.FromResult(mealPlan);
        }

        private MealPlan GenerateMealPlan(MealType mealType, int calories, List<Recipe> recipes)
        {
            InitializeLists(recipes);

            int averageCalories = calories / 3;

            var breakfastRecipes = MealPlannerUtils.FilterByCaloriesAndMealType(averageCalories, mealType, _breakfastRecipes);
            var lunchRecipes = MealPlannerUtils.FilterByCaloriesAndMealType(averageCalories, mealType, _lunchRecipes);
            var dinnerRecipes = MealPlannerUtils.FilterByCaloriesAndMealType(averageCalories, mealType, _dinnerRecipes);

            var random = new Random();
            var mealPlan = new MealPlan();

            mealPlan.Breakfast = breakfastRecipes.ElementAt(random.Next(0, breakfastRecipes.Count));
            mealPlan.Lunch = lunchRecipes.ElementAt(random.Next(0, lunchRecipes.Count));
            mealPlan.Dinner = dinnerRecipes.ElementAt(random.Next(0, dinnerRecipes.Count));

            return mealPlan;
        }

        private void InitializeLists(List<Recipe> recipes)
        {
            _allRecipes = new List<Recipe>(recipes);
            _breakfastRecipes = MealPlannerUtils.FilterByServingTime(ServingTime.Breakfast, _allRecipes);
            _lunchRecipes = MealPlannerUtils.FilterByServingTime(ServingTime.Lunch, _allRecipes);
            _dinnerRecipes = MealPlannerUtils.FilterByServingTime(ServingTime.Dinner, _allRecipes);
        }
    }
}
