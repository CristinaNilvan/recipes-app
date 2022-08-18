namespace RecipesApp.Domain.Models
{
    public class RecipeIngredients
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
