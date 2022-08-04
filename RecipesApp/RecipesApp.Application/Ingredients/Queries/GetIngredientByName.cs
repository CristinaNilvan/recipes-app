using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.Queries
{
    public class GetIngredientByName : IRequest<Ingredient>
    {
        public string IngredientName { get; set; } 
    }
}
