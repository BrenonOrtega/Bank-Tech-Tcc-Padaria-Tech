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
            CreateMap<Recipe, IngredientRecipeReadDto>();
            CreateMap<Product, IngredientProductReadDto>()
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(model => model.StockQuantity));


            CreateMap<IngredientCreateDto, Ingredient>();
            CreateMap<Ingredient, IngredientReadDto>()
                .ForMember(readDto => readDto.Recipe, opt => opt.MapFrom(model => model.Recipe))
                .ForMember(readDto => readDto.Product, opt => opt.MapFrom(model => model.Product));
        }
    }
}