namespace RecipesApp.Assignments.Queries
{
    internal class IngredientStatsDto
    {
        public string CategoryName { get; set; }
        public int NumberOfIngredients { get; set; }

        public override string ToString()
        {
            return $"Category : {CategoryName} ; Number of ingredients : {NumberOfIngredients}";
        }
    }
}