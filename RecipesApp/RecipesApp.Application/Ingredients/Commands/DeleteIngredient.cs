using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.Commands
{
    public class DeleteIngredient : IRequest<Ingredient>
    {
        public int IngredientId { get; set; }
    }
}
