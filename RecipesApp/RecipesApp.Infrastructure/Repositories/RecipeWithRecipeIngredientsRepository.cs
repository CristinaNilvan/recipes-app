using RecipesApp.Application.Abstractions;
using RecipesApp.Infrastructure.Context;

namespace RecipesApp.Infrastructure.Repositories
{
    public class RecipeWithRecipeIngredientsRepository : IRecipeWithRecipeIngredientsRepository
    {
        private readonly DataContext _dataContext;

        public RecipeWithRecipeIngredientsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task DeleteRecipeIngredientsByRecipeId(int recipeId)
        {
            var query = _dataContext
                .RecipeWithRecipeIngredients
                .Where(recipeWithRecipeIngredients => recipeWithRecipeIngredients.RecipeId == recipeId)
                .ToList();

            _dataContext.RemoveRange(query);
        }
    }
}