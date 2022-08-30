namespace RecipesApp.Presentation.Dtos.IngredientImageDtos
{
    public class IngredientImageGetDto
    {
        public int Id { get; set; }
        public string StorageImageUrl { get; set; }
        public int IngredientId { get; set; }
    }
}