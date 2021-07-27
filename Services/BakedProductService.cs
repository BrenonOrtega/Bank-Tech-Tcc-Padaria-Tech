using AutoMapper;
using PadariaTech.Dtos.Create;
using PadariaTech.Dtos.Read;
using PadariaTech.Models;

namespace PadariaTech.Services
{
    public class BakedProductService 
        : BaseService<BakedProduct, BakedProductReadDto, BakedProductCreateDto>
    {
        public BakedProductService(IBakedProductRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}