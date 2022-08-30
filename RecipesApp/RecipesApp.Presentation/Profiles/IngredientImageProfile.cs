using AutoMapper;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.IngredientImageDtos;

namespace RecipesApp.Presentation.Profiles
{
    public class IngredientImageProfile : Profile
    {
        public IngredientImageProfile()
        {
            CreateMap<IngredientImage, IngredientImageGetDto>();
        }
    }
}
