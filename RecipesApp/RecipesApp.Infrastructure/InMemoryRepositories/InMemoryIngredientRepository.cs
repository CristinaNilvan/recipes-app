﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure.InMemoryRepositories
{
    public class InMemoryIngredientRepository : IIngredientRepository
    {
        private List<Ingredient> _ingredients = new List<Ingredient>(PopulateLists.PopulateIngredients());

        public List<Ingredient> Ingredients => _ingredients;

        public void CreateIngredient(Ingredient ingredient)
        {
            ingredient.Id = _ingredients.Count > 0 ? _ingredients.ElementAt(_ingredients.Count - 1).Id + 1 : 1;
            _ingredients.Add(ingredient);
        }

        public void DeleteIngredient(int ingredientId)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            _ingredients.Remove(ingredient);
        }

        public Ingredient GetIngredientById(int ingredientId)
        {
            return _ingredients.FirstOrDefault(x => x.Id == ingredientId);
        }

        public Ingredient GetIngredientByName(string ingredientName)
        {
            return _ingredients.FirstOrDefault(x => x.Name == ingredientName);
        }

        public List<Ingredient> GetAllIngredients()
        {
            return _ingredients;
        }

        public void UpdateIngredient(int ingredientId, Ingredient newIngredient)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            var index = _ingredients.IndexOf(ingredient);
            newIngredient.Id = ingredientId;
            _ingredients[index] = newIngredient;
        }
    }
}
