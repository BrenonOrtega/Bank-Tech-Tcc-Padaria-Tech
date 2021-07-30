using AutoMapper;
using PadariaTech.Domain.Models;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Application.Dtos.Read;

namespace PadariaTech.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Product, IngredientProductReadDto>();
            CreateMap<Recipe, IngredientRecipeReadDto>();

            CreateMap<IngredientCreateDto, Ingredient>();
            CreateMap<Ingredient, IngredientReadDto>()
                .ForMember(readDto => readDto.Recipe, opt => opt.MapFrom(model =>  model.Recipe ))
                .ForMember(readDto => readDto.Product, opt => opt.MapFrom(model => model.Product));
        }
    }
}