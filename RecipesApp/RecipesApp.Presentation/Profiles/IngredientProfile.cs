using AutoMapper;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos;

namespace RecipesApp.Presentation.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientGetDto>();
        }
    }
}
