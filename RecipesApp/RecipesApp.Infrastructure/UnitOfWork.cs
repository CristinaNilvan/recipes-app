using RecipesApp.Application.Abstractions;
using RecipesApp.Infrastructure.Context;

namespace RecipesApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext, IIngredientRepository ingredientRepository,
            IRecipeIngredientRepository recipeIngredientRepository, IRecipeRepository recipeRepository,
            IMealPlanRepository mealPlanRepository)
        {
            _dataContext = dataContext;
            IngredientRepository = ingredientRepository;
            RecipeIngredientRepository = recipeIngredientRepository;
            RecipeRepository = recipeRepository;
            MealPlanRepository = mealPlanRepository;
        }

        public IIngredientRepository IngredientRepository { get; private set; }

        public IRecipeIngredientRepository RecipeIngredientRepository { get; private set; }

        public IRecipeRepository RecipeRepository { get; private set; }

        public IMealPlanRepository MealPlanRepository { get; private set; }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
