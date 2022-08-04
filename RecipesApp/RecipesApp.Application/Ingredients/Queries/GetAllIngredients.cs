using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.Queries
{
    public class GetAllIngredients : IRequest<List<Ingredient>>
    {
    }
}
