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
        private IRecipeRepository _recipeRepository;
        private MealPlanner _mealPlanner;

        public GenerateMealPlanHandler(IMealPlanRepository mealPlanRepository)
        {
            _mealPlanRepository = mealPlanRepository;
        }

        public Task<MealPlan> Handle(GenerateMealPlan request, CancellationToken cancellationToken)
        {
            _mealPlanner = new MealPlanner(request.Recipes);

            var mealPlan = _mealPlanner.GenerateMealPlan(request.MealType, request.Calories);
            _mealPlanRepository.CreateMealPlan(mealPlan);

            return Task.FromResult(mealPlan);
        }
    }
}
