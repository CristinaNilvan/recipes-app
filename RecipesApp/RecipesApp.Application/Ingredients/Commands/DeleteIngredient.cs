﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RecipesApp.Application.Ingredients.Commands
{
    public class DeleteIngredient : IRequest
    {
        public int IngredientId { get; set; }
    }
}