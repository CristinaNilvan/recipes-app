using RecipesApp.Domain.Models;

namespace RecipesApp.Assignments.Queries
{
    internal class RecipeIngredientDetailsDto
    {
        public Ingredient Ingredient { get; set; }
        public float Quantity { get; set; }

        public override string ToString()
        {
            return $"Ingredient : {Ingredient} \n Ingredient quantity : {Quantity} \n";
        }
    }
}
