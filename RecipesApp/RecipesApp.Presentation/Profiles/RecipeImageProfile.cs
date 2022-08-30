using AutoMapper;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.RecipeImageDtos;

namespace RecipesApp.Presentation.Profiles
{
    public class RecipeImageProfile : Profile
    {
        public RecipeImageProfile()
        {
            CreateMap<RecipeImage, RecipeImageGetDto>();
        }
    }
}
