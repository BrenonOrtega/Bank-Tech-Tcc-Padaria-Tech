using AutoMapper;
using PadariaTech.Dtos.Create;
using PadariaTech.Dtos.Read;
using PadariaTech.Models;

namespace PadariaTech.Profiles
{
    public class BakeryProfile : Profile
    {
        public BakeryProfile()
        {
            CreateMap<Product, ProductCreateDto>();
            CreateMap<ProductReadDto, Product>();

            CreateMap<Recipe, RecipeCreateDto>();
            CreateMap<RecipeReadDto, RecipeCreateDto>();
        }
    }
}