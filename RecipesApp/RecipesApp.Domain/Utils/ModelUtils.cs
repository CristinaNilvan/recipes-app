using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApp.Domain.Utils
{
    internal class ModelUtils
    {
        public static float CalculateTwoDecimalFloat(float number) 
            => (float)Math.Round(number * 100f) / 100f;
    }
}
