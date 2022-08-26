using AutoMapper;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos;

namespace RecipesApp.Presentation.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeGetDto>();
        }
    }
}
