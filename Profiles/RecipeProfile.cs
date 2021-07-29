using AutoMapper;
using PadariaTech.Domain.Models;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Application.Dtos.Read;

namespace PadariaTech.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<BakedProduct, RecipeProductReadDto>();
            CreateMap<RecipeCreateDto, Recipe>();

            CreateMap<Recipe, RecipeReadDto>()
                .ForMember(dto => dto.BakedProduct, opt => opt.MapFrom(model => model.BakedProduct))
                .ForMember(dto => dto.Ingredients, opt => opt.MapFrom(model => model.Ingredients));
        }
    }
}