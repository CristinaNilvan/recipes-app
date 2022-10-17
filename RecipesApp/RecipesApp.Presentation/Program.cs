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

// Repositories and Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IIngredientImageRepository, IngredientImageRepository>();
builder.Services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeWithRecipeIngredientsRepository, RecipeWithRecipeIngredientsRepository>();
builder.Services.AddScoped<IRecipeImageRepository, RecipeImageRepository>();
builder.Services.AddScoped<IMealPlanRepository, MealPlanRepository>();
builder.Services.AddScoped<IImageStorageService, ImageStorageService>();

// Data Context
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Indentity Data Context
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

// Blob Storage Settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));
var jwtSettings = builder.Configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();

// Authentication  
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Jwt Bearer  
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidAudience = jwtSettings.ValidAudience,
        ValidIssuer = jwtSettings.ValidIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
    };
});

// Authorization Policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
          policy.RequireRole("Admin"));
});

// MediarR and AutoMapper
builder.Services.AddMediatR(typeof(IApplicationAssemblyMarker));
builder.Services.AddAutoMapper(typeof(IPresentationAssemblyMarker));

// Blob Storage Settings
builder.Services.Configure<BlobStorageSettings>(builder.Configuration.GetSection(nameof(BlobStorageSettings)));
var blobStorageSettings = builder.Configuration.GetSection(nameof(BlobStorageSettings)).Get<BlobStorageSettings>();

// Blob Storage Service
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
