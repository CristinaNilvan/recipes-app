using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Recipe
    {
        private int _id;
        private string? _name;
        private string? _author;
        private string? _description;
        private string? _type;
        private double _calories;
        private List<Ingredient>? _ingredients;
    }
}
