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

        public override int Register(BakedProductCreateDto dto)
        {
            //Example
            //Manipulate dto, make validations, map to model, add relationship.
            //Code here.

            //base.Register(model: newModel);
            throw new System.NotImplementedException();
        }

        public override bool Update(int id, BakedProductCreateDto dto)
        {
            //Example
            //Manipulate dto, make validations, map to model, add relationship.
            //Code here.

            //base.Update(id: id, model: updatedModel);
            throw new System.NotImplementedException();
        }
    }
}