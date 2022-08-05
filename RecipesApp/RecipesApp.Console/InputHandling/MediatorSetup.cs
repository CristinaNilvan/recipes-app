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
        public static IMediator GetMediatorForIngredient()
        {
            var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IIngredientRepository))
                .AddScoped<IIngredientRepository, InMemoryIngredientRepository>()
                .BuildServiceProvider();

            return diContainer.GetRequiredService<IMediator>();
        }

        public static IMediator GetMediatorForRecipe()
        {
            var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IRecipeRepository))
                .AddScoped<IRecipeRepository, InMemoryRecipeRepository>()
                .BuildServiceProvider();

            return diContainer.GetRequiredService<IMediator>();
        }
    }
}
