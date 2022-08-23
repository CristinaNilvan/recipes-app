namespace RecipesApp.Assignments.Queries
{
    internal class RecipeWithRecipeIngredientStatsDto
    {
        public int RecipeId { get; set; }
        public int NumberOfIngredients { get; set; }

        public override string ToString()
        {
            return $"RecipeId : {RecipeId} ; Number of ingredients : {NumberOfIngredients}";
        }
    }
}
