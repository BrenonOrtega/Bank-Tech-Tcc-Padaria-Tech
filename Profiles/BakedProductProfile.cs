using AutoMapper;
using PadariaTech.Dtos.Create;
using PadariaTech.Dtos.Read;
using PadariaTech.Models;

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