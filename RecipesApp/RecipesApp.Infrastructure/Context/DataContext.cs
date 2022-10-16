using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure.Context
{
    public class DataContext : IdentityDbContext<User>
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
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<RecipeImage> RecipeImages { get; set; }
        public DbSet<IngredientImage> IngredientImages { get; set; }
        public DbSet<RecipeWithRecipeIngredient> RecipeWithRecipeIngredients { get; set; }

        // ??
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=DESKTOP-37GIORL\SQLEXPRESS;Database=AppDB;User Id=admin;Password=admin")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }*/
    }
}
