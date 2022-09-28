using RecipesApp.Presentation.Dtos.IngredientDtos;

namespace RecipesApp.Presentation.Dtos.RecipeIngredientDtos
{
    public class RecipeIngredientGetDto
    {
        public int Id { get; set; }
        public float Quantity { get; set; }
        public int IngredientId { get; set; }

        //for recipe?
        public IngredientGetDto Ingredient { get; set; }
    }
}
