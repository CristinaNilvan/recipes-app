using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.MealPlannerFeature.Commands
{
    public class GenerateMealPlan : IRequest<MealPlan>
    {
        public MealType MealType { get; set; }
        public int Calories { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
