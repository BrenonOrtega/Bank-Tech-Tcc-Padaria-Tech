using AutoMapper;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;

namespace PadariaTech.Services
{
    public class ProductService : BaseService<Product, ProductReadDto, ProductCreateDto>
    {
        public ProductService(IProductRepository productRepository, IMapper mapper) 
            : base(productRepository, mapper)
        {
        }

        public override int Register(ProductCreateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public override bool Update(int id, ProductCreateDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}