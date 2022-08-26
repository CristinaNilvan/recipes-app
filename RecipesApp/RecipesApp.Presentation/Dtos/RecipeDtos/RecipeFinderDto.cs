using RecipesApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos.RecipeDtos
{
    public class RecipeFinderDto
    {
        [Required]
        public List<Ingredient> Ingredients { get; set; }
    }
}
