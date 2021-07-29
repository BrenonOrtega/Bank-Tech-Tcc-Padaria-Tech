using AutoMapper;
using PadariaTech.Domain.Models;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Application.Dtos.Read;
using System.Threading.Tasks;

namespace PadariaTech.Application.Services
{
    public class BakedProductService 
        : BaseService<BakedProduct, BakedProductReadDto, BakedProductCreateDto>
    {
        public BakedProductService(IBakedProductRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }

        protected override BakedProduct GetCreatedModel(BakedProductCreateDto dto)
        {
            throw new System.NotImplementedException();
        }

        protected override BakedProduct GetUpdatedModel(int id, BakedProductCreateDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}