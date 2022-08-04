using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RecipesApp.Domain.Models;
using RecipesApp.Domain.Enums;

namespace RecipesApp.Application.Ingredients.Commands
{
    public class UpdateIngredient : IRequest
    {
        public int IngredientId { get; set; }
        public string? Name { get; set; }
        public IngredientCategory Category { get; set; }
        public int Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
        public double Quantity { get; set; }
    }
}
