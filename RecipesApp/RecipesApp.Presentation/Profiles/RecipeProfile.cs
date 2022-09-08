using AutoMapper;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.RecipeDtos;

namespace RecipesApp.Presentation.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeGetDto>()
                .ForMember(recipeGetDto => recipeGetDto.RecipeIngredients, recipe => recipe
                .MapFrom(recipe => recipe.RecipeWithRecipeIngredients
                .Select(recipeWithIngredient => recipeWithIngredient.RecipeIngredient)));
            CreateMap<RecipeGetDto, Recipe>();
            CreateMap<MealPlan, MealPlannerGetDto>(); // delete if not needed for meal planner
        }
    }
}
