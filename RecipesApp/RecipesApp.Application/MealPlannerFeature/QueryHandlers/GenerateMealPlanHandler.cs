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
            float averageCalories = FeaturesUtils.CalculateTwoDecimalFloat(calories / 3);
            await InitializeLists(averageCalories, mealType);

            if (_breakfastRecipes == null || _lunchRecipes == null || _dinnerRecipes == null)
            {
                return null;
            }

            var random = new Random();

            var breakfast = _breakfastRecipes.ElementAt(random.Next(0, _breakfastRecipes.Count));
            var lunch = _lunchRecipes.ElementAt(random.Next(0, _lunchRecipes.Count));
            var dinner = _dinnerRecipes.ElementAt(random.Next(0, _dinnerRecipes.Count));

            var mealPlan = new MealPlan(breakfast, lunch, dinner);

            return mealPlan;
        }

        private async Task InitializeLists(float averageCalories, MealType mealType)
        {
            _breakfastRecipes = await GetRecipeList(averageCalories, mealType, ServingTime.Breakfast);
            _lunchRecipes = await GetRecipeList(averageCalories, mealType, ServingTime.Lunch);
            _dinnerRecipes = await GetRecipeList(averageCalories, mealType, ServingTime.Dinner);
        }

        private async Task<List<Recipe>> GetRecipeList(float averageCalories, MealType mealType, ServingTime servingTime)
        {
            var recipeList = (await _unitOfWork
                .RecipeRepository
                .GetByMealPlannerCriteria(averageCalories, mealType, servingTime))
                .ToList();

            if (recipeList.Count != 0)
            {
                return recipeList;
            }

            var newAverageCalories = averageCalories + (averageCalories / 2);
            newAverageCalories = FeaturesUtils.CalculateTwoDecimalFloat(newAverageCalories);

            recipeList = (await _unitOfWork
                .RecipeRepository
                .GetByMealPlannerCriteria(newAverageCalories, mealType, servingTime))
                .ToList();

            if (recipeList.Count != 0)
            {
                return recipeList;
            }

            return null;
        }
    }
}
