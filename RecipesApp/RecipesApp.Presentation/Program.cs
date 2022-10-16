using Azure.Storage.Blobs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RecipesApp.Application;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Abstractions.Repositories;
using RecipesApp.Application.Abstractions.Services;
using RecipesApp.Application.Settings;
using RecipesApp.Domain.Models;
using RecipesApp.Infrastructure;
using RecipesApp.Infrastructure.Context;
using RecipesApp.Infrastructure.Repositories;
using RecipesApp.Infrastructure.Services;
using RecipesApp.Presentation;
using RecipesApp.Presentation.Middleware;
using System.Text;

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
builder.Services.AddScoped<IImageStorageService, ImageStorageService>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidAudience = "audience",
        ValidIssuer = "https://localhost:7212",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
          policy.RequireRole("Admin"));
});

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

app.UseAuthentication();
app.UseAuthorization();
app.UseRequestLoggingMiddleware();

app.MapControllers();

app.Run();
