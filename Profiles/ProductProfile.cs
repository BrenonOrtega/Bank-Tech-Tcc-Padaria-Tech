using AutoMapper;
using PadariaTech.Domain.Models;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Application.Dtos.Read;

namespace PadariaTech.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}