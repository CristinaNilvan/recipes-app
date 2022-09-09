using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions.Repositories
{
    public interface IRecipeRepository
    {
        Task Create(Recipe recipe);
        Task<Recipe> GetById(int recipeId);
        Task Delete(Recipe recipe);
        Task<IQueryable<Recipe>> GetAll(PaginationParameters paginationParameters);
        Task<IQueryable<Recipe>> GetByName(PaginationParameters paginationParameters, string recipeName);
        Task<IQueryable<Recipe>> GetByApprovedStatusWithPagination(PaginationParameters paginationParameters, bool approvedStatus);
        Task<IQueryable<Recipe>> GetByMealPlannerCriteria(float calories, MealType mealType, ServingTime servingTime);
        Task<IQueryable<Recipe>> GetByIngredientAndQuantity(PaginationParameters paginationParameters, float ingredientQuantity, string ingredientName);
        Task<IQueryable<Recipe>> GetBestMatchByIngredientAndQuantity(PaginationParameters paginationParameters, float ingredientQuantity, string ingredientName);
        Task<IQueryable<Recipe>> GetByContainingOneOfGivenIngredients(List<int> ingredientIds);
        Task<IQueryable<int>> GetIngredientIdsByRecipeId(int recipeId);
    }
}