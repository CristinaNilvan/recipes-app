﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Infrastructure.Context;
using RecipesApp.Infrastructure.InMemoryRepositories;
using RecipesApp.Infrastructure.Repositories;

namespace RecipesApp.Console.TestFunctionalities
{
    internal class NewMediatorSetup
    {
        private static IMediator _mediator;

        public static IMediator GetMediator()
        {

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