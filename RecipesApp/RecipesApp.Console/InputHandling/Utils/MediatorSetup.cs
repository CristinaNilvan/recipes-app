using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipesApp.Application.Abstractions;
using RecipesApp.Infrastructure.Context;
using RecipesApp.Infrastructure.Repositories;

namespace RecipesApp.Console.InputHandling.Utils
{
    internal class MediatorSetup
    {
        private static IMediator _mediator;

        public static IMediator GetMediator()
        {

            /*if (_mediator == null)
            {
                var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IIngredientRepository))
                .AddScoped<IIngredientRepository, InMemoryIngredientRepository>()
                .AddScoped<IRecipeRepository, InMemoryRecipeRepository>()
                .AddScoped<IMealPlanRepository, InMemoryMealPlanRepository>()
                .BuildServiceProvider();

                _mediator = diContainer.GetRequiredService<IMediator>();
            }*/

            if (_mediator == null)
            {
                var diContainer = new ServiceCollection()
                    .AddDbContext<DataContext>(options =>
                        options.UseSqlServer(@"Server=DESKTOP-37GIORL\SQLEXPRESS;Database=RecipesApplicationDB;User Id=admin;Password=admin"))
                    .AddMediatR(typeof(IIngredientRepository))
                    .AddScoped<IIngredientRepository, IngredientRepository>()
                    .AddScoped<IRecipeRepository, RecipeRepository>()
                    .AddScoped<IMealPlanRepository, MealPlanRepository>()
                    .BuildServiceProvider();

                _mediator = diContainer.GetRequiredService<IMediator>();
            }

            return _mediator;
        }
    }
}
