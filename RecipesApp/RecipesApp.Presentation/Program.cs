using Azure.Storage.Blobs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application;
using RecipesApp.Application.Abstractions;
using RecipesApp.Infrastructure;
using RecipesApp.Infrastructure.Context;
using RecipesApp.Infrastructure.Repositories;
using RecipesApp.Infrastructure.Services;
using RecipesApp.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IMealPlanRepository, MealPlanRepository>();
builder.Services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
builder.Services.AddScoped<IRecipeWithRecipeIngredientsRepository, RecipeWithRecipeIngredientsRepository>();
builder.Services.AddScoped<IRecipeImageRepository, RecipeImageRepository>();
builder.Services.AddSingleton<IBlobService, BlobService>();     // review!!!! addScoped?

builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var blobConnection = builder.Configuration.GetValue<string>("AzureBlobStorageConnectionString");
builder.Services.AddSingleton(blobService => new BlobServiceClient(blobConnection));

builder.Services.AddMediatR(typeof(IApplicationAssemblyMarker));
builder.Services.AddAutoMapper(typeof(IPresentationAssemblyMarker));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
