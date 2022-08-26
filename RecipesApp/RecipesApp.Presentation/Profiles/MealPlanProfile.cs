using AutoMapper;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.MealPlanDtos;

namespace RecipesApp.Presentation.Profiles
{
    public class MealPlanProfile : Profile
    {
        public MealPlanProfile()
        {
            CreateMap<MealPlan, MealPlanGetDto>();
        }
    }
}
