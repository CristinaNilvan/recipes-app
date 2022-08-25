﻿using AutoMapper;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos;

namespace RecipesApp.Presentation.Profiles
{
    public class RecipeIngredientProfile : Profile
    {
        public RecipeIngredientProfile()
        {
            CreateMap<RecipeIngredient, RecipeIngredientGetDto>();
        }
    }
}
