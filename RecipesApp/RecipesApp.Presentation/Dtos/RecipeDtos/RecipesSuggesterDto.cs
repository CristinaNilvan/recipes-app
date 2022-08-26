using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos.RecipeDtos
{
    public class RecipesSuggesterDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string IngredientName { get; set; }

        [Required]
        [Range(1, 5000)]
        public float IngredientQuantity { get; set; }
    }
}
