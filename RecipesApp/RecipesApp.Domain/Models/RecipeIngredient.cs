namespace RecipesApp.Domain.Models
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public float Quantity { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
