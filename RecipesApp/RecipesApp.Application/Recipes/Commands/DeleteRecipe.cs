using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RecipesApp.Application.Recipes.Commands
{
    public class DeleteRecipe : IRequest
    {
        public int RecipeId { get; set; }
    }
}
