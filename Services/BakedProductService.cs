using AutoMapper;
using PadariaTech.Domain.Models;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Application.Dtos.Read;

namespace PadariaTech.Services
{
    public class BakedProductService 
        : BaseService<BakedProduct, BakedProductReadDto, BakedProductCreateDto>
    {
        public BakedProductService(IBakedProductRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }

        public int Register(BakedProductCreateDto model)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(BakedProductCreateDto model)
        {
            throw new System.NotImplementedException();
        }
    }
}