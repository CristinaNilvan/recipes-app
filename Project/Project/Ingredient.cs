using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Ingredient
    {
        public Ingredient(int id, string? name, string? type, int calories, double quantity)
        {
            Id = id;
            Name = name;
            Type = type;
            Calories = calories;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int Calories { get; set; }
        public double Quantity { get; set; }
    }
}
