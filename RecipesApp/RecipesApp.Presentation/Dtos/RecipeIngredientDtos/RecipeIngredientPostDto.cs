using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos.RecipeIngredientDtos
{
    public class RecipeIngredientPostDto
    {
        [Required]
        [Range(1, 5000)]
        public float Quantity { get; set; }

        // ??
        [Required]
        public int IngredientId { get; set; }
    }
}
