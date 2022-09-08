using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos.MealPlanDtos
{
    public class MealPlanPostDto
    {
        [Required]
        public Recipe Breakfast { get; set; }

        [Required]
        public Recipe Lunch { get; set; }

        [Required]
        public Recipe Dinner { get; set; }
    }
}
