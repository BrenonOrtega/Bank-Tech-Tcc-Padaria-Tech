using AutoMapper;
using System.Threading.Tasks;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Domain.Models;

namespace PadariaTech.Application.Services
{
    public class SoldItemService
        : BaseService<SoldItem, SoldItemReadDto, SoldItemCreateDto>
    {
        public SoldItemService(ISoldItemRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        protected override Task<SoldItem> GetCreatedModel(SoldItemCreateDto dto)
        {
            throw new System.NotImplementedException();
        }

        protected override Task<SoldItem> GetUpdatedModel(int id, SoldItemCreateDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}