using AutoMapper;
using PadariaTech.Dtos.Create;
using PadariaTech.Dtos.Read;
using PadariaTech.Models;

namespace PadariaTech.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<BakedProduct, RecipeProductReadDto>();
            CreateMap<Ingredient, IngredientReadDto>();

            CreateMap<RecipeCreateDto, Recipe>();

            CreateMap<Recipe, RecipeReadDto>()
                .ForMember(dto => dto.BakedProduct, opt => opt.MapFrom(model => model.BakedProduct))
                .ForMember(dto => dto.Ingredients, opt => opt.MapFrom(model => model.Ingredients));
        }
    }
}