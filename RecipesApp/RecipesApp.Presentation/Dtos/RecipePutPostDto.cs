using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos
{
    public class RecipePutPostDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(70)]
        public string Author { get; set; }

        [Required]
        [MaxLength(10000)]
        public string Description { get; set; }

        [Required]
        public MealType MealType { get; set; }

        [Required]
        public ServingTime ServingTime { get; set; }

        [Required]
        [Range(1, 25)]
        public float Servings { get; set; }
        //public List<RecipeIngredient> RecipeIngredients { get; set; }

        [Required]
        public List<RecipeWithRecipeIngredient> RecipeWithRecipeIngredients { get; set; }
    }
}
