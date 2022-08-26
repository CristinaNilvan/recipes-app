using AutoMapper;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.RecipeDtos;
using RecipesApp.Presentation.Dtos.RecipeIngredientDtos;

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

            CreateMap<RecipeIngredient, RecipeIngredientGetDto>();
        }
    }
}
