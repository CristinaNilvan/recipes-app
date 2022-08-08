using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RecipesApp.Application.Abstractions;
using RecipesApp.Infrastructure.InMemoryRepositories;

namespace RecipesApp.Console.InputHandling
{
    internal class MediatorSetup
    {
        private static IMediator _mediator;

        public static IMediator GetMediator()
        {

            if (_mediator == null)
            {
                var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IIngredientRepository))
                .AddScoped<IIngredientRepository, InMemoryIngredientRepository>()
                .AddScoped<IRecipeRepository, InMemoryRecipeRepository>()
                .AddScoped<IMealPlanRepository, InMemoryMealPlanRepository>()
                .BuildServiceProvider();

                _mediator = diContainer.GetRequiredService<IMediator>();
            }

            return _mediator;
        }
    }
}
