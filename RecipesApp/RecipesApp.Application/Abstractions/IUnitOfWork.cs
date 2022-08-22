namespace RecipesApp.Application.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        public IIngredientRepository IngredientRepository { get; }
        public IRecipeIngredientRepository RecipeIngredientRepository { get; }
        public IRecipeRepository RecipeRepository { get; }
        public IMealPlanRepository MealPlanRepository { get; }
        Task Save();
    }
}
