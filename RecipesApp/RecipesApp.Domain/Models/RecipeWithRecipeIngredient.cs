namespace RecipesApp.Domain.Models
{
    public class RecipeWithRecipeIngredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeIngredientId { get; set; }
        public RecipeIngredient RecipeIngredient { get; set; }
    }
}
