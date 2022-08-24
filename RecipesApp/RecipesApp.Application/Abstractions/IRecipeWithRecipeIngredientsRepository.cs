namespace RecipesApp.Application.Abstractions
{
    public interface IRecipeWithRecipeIngredientsRepository
    {
        Task DeleteRecipeIngredientsByRecipeId(int recipeId);
    }
}
