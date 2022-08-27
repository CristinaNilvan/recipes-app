using RecipesApp.Domain.Utils;

namespace RecipesApp.Domain.Models
{
    public class RecipeIngredient
    {
        private float _quantity;

        public RecipeIngredient()
        {

        }

        public RecipeIngredient(int id, float quantity, int ingredientId)
        {
            Id = id;
            Quantity = quantity;
            IngredientId = ingredientId;
        }

        public RecipeIngredient(float quantity, int ingredientId)
        {
            Quantity = quantity;
            IngredientId = ingredientId;
        }

        public int Id { get; set; }
        public float Quantity { get => _quantity; set => _quantity = ModelUtils.CalculateTwoDecimalFloat(value); }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public List<RecipeWithRecipeIngredient> RecipeWithRecipeIngredients { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}; Quantity : {Quantity}; IngredientId : {IngredientId}";
        }
    }
}
