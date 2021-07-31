using AutoMapper;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;

namespace PadariaTech.Application.Services
{
    public class ProductService : BaseService<Product, ProductReadDto, ProductCreateDto>
    {
        public ProductService(IProductRepository productRepository, IMapper mapper)
            : base(productRepository, mapper)
        {
        }

        protected override Task<Product> GetCreatedModel(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            var exists = _repository
                .Get(prod => prod.Name == dto.Name && prod.Measure == dto.Measure && prod.Type == product.Type)
                .Any();

            if (exists)
                throw new ArgumentException("Similar product already exists");

            return Task.FromResult(product);
        }

        protected override async Task<Product> GetUpdatedModel(int id, ProductCreateDto dto)
        {
            var updatedProduct = _mapper.Map<Product>(dto);
            updatedProduct.Id = id;

            var originalProduct = await _repository.GetById(id);

            if (originalProduct is null)
            {
                throw new KeyNotFoundException("This Product does not exists");
            }

            return updatedProduct;
        }
    }
}