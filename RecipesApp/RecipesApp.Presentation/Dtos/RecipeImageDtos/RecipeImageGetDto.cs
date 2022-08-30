namespace RecipesApp.Presentation.Dtos.RecipeImageDtos
{
    public class RecipeImageGetDto
    {
        public int Id { get; set; }
        public string StorageImageUrl { get; set; }
        public int RecipeId { get; set; }
    }
}
