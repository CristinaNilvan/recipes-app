using Microsoft.EntityFrameworkCore;
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
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<RecipeWithRecipeIngredient> RecipeWithRecipeIngredients { get; set; }
    }
}
