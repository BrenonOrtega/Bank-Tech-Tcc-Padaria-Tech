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
            CreateMap<ProductCreateDto, Product>();
            
            CreateMap<Product, ProductReadDto>()
                .ForMember(dto => dto.ProductType, opt => opt.MapFrom(model => model.Type))
                .IncludeAllDerived();
        }
    }
}