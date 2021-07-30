using AutoMapper;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace PadariaTech.Application.Services
{
    public class ProductService : BaseService<Product, ProductReadDto, ProductCreateDto>
    {
        public ProductService(IProductRepository productRepository, IMapper mapper) 
            : base(productRepository, mapper)
        {
        }

        protected override async Task<Product> GetCreatedModel(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            var exists = _repository
                .Get(prod => prod.Name == dto.Name && prod.Measure == dto.Measure && prod.Type == product.Type)
                .Any();

            if(exists)
                throw new ArgumentException("Similar product already exists");
            
            return product;
        }

        protected override async Task<Product> GetUpdatedModel(int id, ProductCreateDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}