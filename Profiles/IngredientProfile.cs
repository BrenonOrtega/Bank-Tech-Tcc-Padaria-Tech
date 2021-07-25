using AutoMapper;
using PadariaTech.Models;
using PadariaTech.Dtos.Create;
using PadariaTech.Dtos.Read;

namespace PadariaTech.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Product, IngredientProductReadDto>();
            CreateMap<Recipe, IngredientRecipeReadDto>();

            CreateMap<Ingredient, IngredientReadDto>()
                .ForMember(readDto => readDto.Recipe, opt => opt.MapFrom(model => model.Recipe))
                .ForMember(readDto => readDto.Product, opt => opt.MapFrom(model => model.Product));


        }        
    }
}