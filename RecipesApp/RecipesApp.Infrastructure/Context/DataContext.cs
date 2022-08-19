using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer(@"Server=DESKTOP-37GIORL\SQLEXPRESS;Database=RecipesAppsDB;User Id=admin;Password=admin")
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
            .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Ingredient>()
                .Ignore(ingredient => ingredient.Quantity);*/
        }
    }
}
