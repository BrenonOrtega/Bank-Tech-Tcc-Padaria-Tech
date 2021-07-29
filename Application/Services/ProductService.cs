using AutoMapper;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;
using System.Threading.Tasks;

namespace PadariaTech.Application.Services
{
    public class ProductService : BaseService<Product, ProductReadDto, ProductCreateDto>
    {
        public ProductService(IProductRepository productRepository, IMapper mapper) 
            : base(productRepository, mapper)
        {
        }

        protected override Product GetCreatedModel(ProductCreateDto dto)
        {
            throw new System.NotImplementedException();
        }

        protected override Product GetUpdatedModel(int id, ProductCreateDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}