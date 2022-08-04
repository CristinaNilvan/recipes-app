using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.Queries
{
    public class GetIngredientById : IRequest<Ingredient>
    {
        public int IngredientId { get; set; }
    }
}
