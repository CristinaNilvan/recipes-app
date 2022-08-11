using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.MealPlannerFeature.Commands;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;
using System.Reflection;
using System;

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

        public async Task<MealPlan> Handle(GenerateMealPlan request, CancellationToken cancellationToken)
        {
            var mealPlan = GenerateMealPlan(request.MealType, request.Calories, request.Recipes);
            await _mealPlanRepository.CreateMealPlan(mealPlan);

            return mealPlan;
        }

        private MealPlan GenerateMealPlan(MealType mealType, float calories, List<Recipe> recipes)
        {
            InitializeLists(recipes);

            float averageCalories = MealPlannerUtils.CalculateTwoDecimalFloat(calories / 3);

            var breakfastRecipes = MealPlannerUtils.GetRecipes(averageCalories, mealType, _breakfastRecipes);
            var lunchRecipes = MealPlannerUtils.GetRecipes(averageCalories, mealType, _lunchRecipes);
            var dinnerRecipes = MealPlannerUtils.GetRecipes(averageCalories, mealType, _dinnerRecipes);

            var random = new Random();

            var breakfast = breakfastRecipes.ElementAt(random.Next(0, breakfastRecipes.Count));
            var lunch = lunchRecipes.ElementAt(random.Next(0, lunchRecipes.Count));
            var dinner = dinnerRecipes.ElementAt(random.Next(0, dinnerRecipes.Count));

            var mealPlan = new MealPlan(breakfast, lunch, dinner);

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
