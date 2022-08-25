using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipesApp.Application.Abstractions;
using RecipesApp.Infrastructure;
using RecipesApp.Infrastructure.Context;
using RecipesApp.Infrastructure.Repositories;

namespace RecipesApp.Console.InputHandling.Utils
{
    internal class MediatorSetup
    {
        private static IMediator _mediator;

        public static IMediator GetMediator()
        {
            if (_mediator == null)
            {
                var diContainer = new ServiceCollection()
                    .AddDbContext<DataContext>(options =>
                        options.UseSqlServer(@"Server=DESKTOP-37GIORL\SQLEXPRESS;Database=RecipesAppDB;User Id=admin;Password=admin"))
                    .AddMediatR(typeof(IUnitOfWork))
                    .AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddScoped<IIngredientRepository, IngredientRepository>()
                    .AddScoped<IRecipeRepository, RecipeRepository>()
                    .AddScoped<IMealPlanRepository, MealPlanRepository>()
                    .AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>()
                    .AddScoped<IRecipeWithRecipeIngredientsRepository, RecipeWithRecipeIngredientsRepository>()
                    .BuildServiceProvider();

                _mediator = diContainer.GetRequiredService<IMediator>();
            }

            return _mediator;
        }
    }
}
