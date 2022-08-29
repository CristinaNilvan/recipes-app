namespace RecipesApp.Domain.Models
{
    public class RecipeImage
    {
        public int Id { get; set; }
        public string StorageImageUrl { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}