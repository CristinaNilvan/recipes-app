using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class RecipeType
    {   
        public int Id { get; set; }
        public MealType MealType { get; set; }
        public ServingTime ServingTime { get; set; }
    }
}
