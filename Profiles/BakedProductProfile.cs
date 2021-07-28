using AutoMapper;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Domain.Models;

namespace PadariaTech.Profiles
{
    public class BakedProductProfile : Profile
    {
        public BakedProductProfile()
        {
            CreateMap<BakedProductCreateDto, BakedProduct>();

            CreateMap<BakedProduct, BakedProductReadDto>()
                .ForMember(readDto => readDto.Recipe, opt => opt.MapFrom(model => model.Recipe));

            CreateMap<Recipe, BakedProductRecipeReadDto>();
        }
    }
}