using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.MealPlannerFeature.Commands;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.MealPlannerFeature.CommandHandlers
{
    public class GenerateMealPlanHandler : IRequestHandler<GenerateMealPlan, MealPlan>
    {
        private readonly IUnitOfWork _unitOfWork;

        private List<Recipe> _allRecipes;
        private List<Recipe> _breakfastRecipes;
        private List<Recipe> _lunchRecipes;
        private List<Recipe> _dinnerRecipes;

        public GenerateMealPlanHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MealPlan> Handle(GenerateMealPlan request, CancellationToken cancellationToken)
        {
            var mealPlan = await GenerateMealPlan(request.MealType, request.Calories);
            await _unitOfWork.MealPlanRepository.CreateMealPlan(mealPlan);
            await _unitOfWork.Save();

            return mealPlan;
        }

        private async Task<MealPlan> GenerateMealPlan(MealType mealType, float calories)
        {
            await InitializeLists();

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

        private async Task InitializeLists()
        {
            _allRecipes = await _unitOfWork.RecipeRepository.GetAllRecipes();
            _breakfastRecipes = MealPlannerUtils.FilterByServingTime(ServingTime.Breakfast, _allRecipes);
            _lunchRecipes = MealPlannerUtils.FilterByServingTime(ServingTime.Lunch, _allRecipes);
            _dinnerRecipes = MealPlannerUtils.FilterByServingTime(ServingTime.Dinner, _allRecipes);
        }
    }
}
