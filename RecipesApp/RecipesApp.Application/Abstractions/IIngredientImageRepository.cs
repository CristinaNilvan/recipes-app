using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    internal interface IIngredientImageRepository
    {
        Task Create(IngredientImage ingredientImage);
        Task Delete(IngredientImage ingredientImage);
    }
}
