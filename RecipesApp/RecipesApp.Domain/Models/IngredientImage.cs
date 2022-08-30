namespace RecipesApp.Domain.Models
{
    public class IngredientImage
    {
        public int Id { get; set; }
        public string StorageImageUrl { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
