using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IIngredientRepository
    {
        void CreateIngredient(Ingredient ingredient);
        Ingredient GetIngredient(int ingredientId);
        void UpdateIngredient(int ingredientId, Ingredient newIngredient);
        void DeleteIngredient(int ingredientId);
        List<Ingredient> GetIngredients();
    }
}
