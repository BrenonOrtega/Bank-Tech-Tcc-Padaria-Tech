using System;
using AutoMapper;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Domain.Enum;
using PadariaTech.Domain.Models;

namespace PadariaTech.Profiles
{
    public class BakedProductProfile : Profile
    {
        public BakedProductProfile()
        {
            CreateMap<Recipe, BakedProductRecipeReadDto>();

            CreateMap<BakedProductCreateDto, BakedProduct>()
                .ForMember(model => model.Recipe, options => options.Ignore())
                .ForMember(model => model.Type, options => options.MapFrom(dto => dto.ProductType));

            CreateMap<BakedProduct, BakedProductReadDto>()
               ;
        }
    }
}