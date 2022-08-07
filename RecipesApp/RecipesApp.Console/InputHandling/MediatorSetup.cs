using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RecipesApp.Application.Abstractions;
using RecipesApp.Infrastructure.InMemoryRepositories;

namespace RecipesApp.Console.InputHandling
{
    internal class MediatorSetup
    {
        private static IMediator _ingredientMediator;
        private static IMediator _recipeMediator;
        private static IMediator _mealPlanMediator;
        public static IMediator GetMediatorForIngredient()
        {
            if (_ingredientMediator == null)
            {
                var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IIngredientRepository))
                .AddScoped<IIngredientRepository, InMemoryIngredientRepository>()
                .BuildServiceProvider();

                _ingredientMediator =  diContainer.GetRequiredService<IMediator>();
            }

            return _ingredientMediator;
        }

        public static IMediator GetMediatorForRecipe()
        {
            if (_recipeMediator == null)
            {
                var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IRecipeRepository))
                .AddScoped<IRecipeRepository, InMemoryRecipeRepository>()
                .BuildServiceProvider();

                _recipeMediator = diContainer.GetRequiredService<IMediator>();
            }

            return _recipeMediator;
        }

        public static IMediator GetMediatorForMealPlan()
        {
            if (_mealPlanMediator == null)
            {
                var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IMealPlanRepository))
                .AddScoped<IMealPlanRepository, InMemoryMealPlanRepository>()
                .BuildServiceProvider();

                _mealPlanMediator = diContainer.GetRequiredService<IMediator>();
            }

            return _mealPlanMediator;
        }
    }
}
