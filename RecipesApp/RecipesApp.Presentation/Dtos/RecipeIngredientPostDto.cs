using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos
{
    public class RecipeIngredientPostDto
    {
        [Required]
        [Range(1, 5000)]
        public float Quantity { get; set; }

        // ??
        //public int IngredientId { get; set; }
    }
}
