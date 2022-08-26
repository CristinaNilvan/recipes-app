using AutoMapper;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.IngredientDtos;

namespace RecipesApp.Presentation.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientGetDto>();
            CreateMap<IngredientPutPostDto, Ingredient>();
        }
    }
}
