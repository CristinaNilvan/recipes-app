using RecipesApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos.RecipeDtos
{
    public class RecipePatchDto
    {
        [MaxLength(100)]
        [MinLength(2)]
        public string Name { get; set; }

        [MaxLength(70)]
        [MinLength(2)]
        public string Author { get; set; }

        [MaxLength(10000)]
        [MinLength(0)]
        public string Description { get; set; }

        public MealType? MealType { get; set; }

        public ServingTime? ServingTime { get; set; }

        [Range(1, 25)]
        public float? Servings { get; set; }
    }
}
