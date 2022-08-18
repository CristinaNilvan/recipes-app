﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<Recipe> Recipes => Set<Recipe>();
        public DbSet<MealPlan> MealPlans => Set<MealPlan>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer(@"Server=DESKTOP-37GIORL\SQLEXPRESS;Database=RecipesApplicationDB;User Id=admin;Password=admin")
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
            .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .Ignore(ingredient => ingredient.Quantity);
        }
    }
}