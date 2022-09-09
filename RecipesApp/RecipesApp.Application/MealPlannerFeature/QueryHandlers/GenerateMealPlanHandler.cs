using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.MealPlannerFeature.Queries;
using RecipesApp.Application.Utils;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.MealPlannerFeature.QueryHandlers
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
            return await GenerateMealPlan(request.MealType, request.Calories);
        }

        private async Task<MealPlan> GenerateMealPlan(MealType mealType, float calories)
        {
            await InitializeLists();

            float averageCalories = FeaturesUtils.CalculateTwoDecimalFloat(calories / 3);

            var breakfastRecipes = FeaturesUtils.GetRecipesForMealPlan(averageCalories, mealType, _breakfastRecipes);
            var lunchRecipes = FeaturesUtils.GetRecipesForMealPlan(averageCalories, mealType, _lunchRecipes);
            var dinnerRecipes = FeaturesUtils.GetRecipesForMealPlan(averageCalories, mealType, _dinnerRecipes);

            var random = new Random();

            var breakfast = breakfastRecipes.ElementAt(random.Next(0, breakfastRecipes.Count));
            var lunch = lunchRecipes.ElementAt(random.Next(0, lunchRecipes.Count));
            var dinner = dinnerRecipes.ElementAt(random.Next(0, dinnerRecipes.Count));

            var mealPlan = new MealPlan(breakfast, lunch, dinner);

            return mealPlan;
        }

        private async Task InitializeLists()
        {
            _allRecipes = (await _unitOfWork.RecipeRepository.GetByApprovedStatusWithoutPagination(true)).ToList();
            _breakfastRecipes = FeaturesUtils.FilterByServingTime(ServingTime.Breakfast, _allRecipes);
            _lunchRecipes = FeaturesUtils.FilterByServingTime(ServingTime.Lunch, _allRecipes);
            _dinnerRecipes = FeaturesUtils.FilterByServingTime(ServingTime.Dinner, _allRecipes);
        }
    }
}
