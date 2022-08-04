using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.MealPlannerFeature.Commands;
using RecipesApp.Domain.Logic;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.MealPlannerFeature.CommandHandlers
{
    public class GenerateMealPlanHandler : IRequestHandler<GenerateMealPlan, MealPlan>
    {
        private readonly IMealPlanRepository _mealPlanRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly MealPlanner _mealPlanner;

        public GenerateMealPlanHandler(IMealPlanRepository mealPlanRepository, IRecipeRepository recipeRepository, 
            MealPlanner mealPlanner)
        {
            _mealPlanRepository = mealPlanRepository;
            _recipeRepository = recipeRepository;
            _mealPlanner = mealPlanner;
        }

        public Task<MealPlan> Handle(GenerateMealPlan request, CancellationToken cancellationToken)
        {
            var recipes = _recipeRepository.GetAllRecipes();
            var mealPlan = _mealPlanner.GenerateMealPlan(request.MealType, request.Calories);
            _mealPlanRepository.CreateMealPlan(mealPlan);

            return Task.FromResult(mealPlan);
        }
    }
}
