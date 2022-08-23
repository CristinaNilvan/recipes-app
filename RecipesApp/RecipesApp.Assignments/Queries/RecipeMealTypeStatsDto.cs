namespace RecipesApp.Assignments.Queries
{
    internal class RecipeMealTypeStatsDto
    {
        public string MealType { get; set; }
        public float AverageCalories { get; set; }

        public override string ToString()
        {
            return $"MealType : {MealType} ; Average number of calories : {AverageCalories}";
        }
    }
}
