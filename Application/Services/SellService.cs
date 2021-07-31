using AutoMapper;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Domain.Interfaces;
using PadariaTech.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PadariaTech.Application.Services
{
    public class SellService : BaseService<Sell, SellReadDto, SellCreateDto>
    {
        public SellService(ISellRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        protected override Task<Sell> GetCreatedModel(SellCreateDto dto)
        {
            throw new NotImplementedException();
        }

        protected override Task<Sell> GetUpdatedModel(int id, SellCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
