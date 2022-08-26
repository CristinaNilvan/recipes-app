using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Presentation.Dtos
{
    public class RecipeGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public MealType MealType { get; set; }
        public ServingTime ServingTime { get; set; }
        public float Servings { get; set; }
        public float Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
        //public List<RecipeIngredient> RecipeIngredients { get; set; }
        public List<RecipeWithRecipeIngredient> RecipeWithRecipeIngredients { get; set; }
    }
}
