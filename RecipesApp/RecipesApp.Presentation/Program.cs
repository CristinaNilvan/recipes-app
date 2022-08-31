using Azure.Storage.Blobs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RecipesApp.Application;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Settings;
using RecipesApp.Infrastructure;
using RecipesApp.Infrastructure.Context;
using RecipesApp.Infrastructure.Repositories;
using RecipesApp.Infrastructure.Services;
using RecipesApp.Presentation;
using RecipesApp.Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IIngredientImageRepository, IngredientImageRepository>();
builder.Services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeWithRecipeIngredientsRepository, RecipeWithRecipeIngredientsRepository>();
builder.Services.AddScoped<IRecipeImageRepository, RecipeImageRepository>();
builder.Services.AddScoped<IMealPlanRepository, MealPlanRepository>();
builder.Services.AddScoped<IBlobService, BlobService>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddMediatR(typeof(IApplicationAssemblyMarker));
builder.Services.AddAutoMapper(typeof(IPresentationAssemblyMarker));

builder.Services.Configure<BlobStorageSettings>(
    builder.Configuration.GetSection(nameof(BlobStorageSettings)));

var blobStorageSettings = builder.Configuration.GetSection(nameof(BlobStorageSettings))
    .Get<BlobStorageSettings>();
builder.Services.AddSingleton(blobService => new BlobServiceClient(blobStorageSettings.ConnectionString));

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
app.UseRequestLoggingMiddleware();

app.MapControllers();

app.Run();
