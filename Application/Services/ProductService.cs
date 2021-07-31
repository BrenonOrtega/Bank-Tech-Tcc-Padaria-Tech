using AutoMapper;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using PadariaTech.Domain.Enum;

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
                throw new KeyNotFoundException($"Product with Id {id} does not exist.");
            }

            return updatedProduct;
        }

        public async Task<(decimal UnitaryValue, ProductReadDto SoldProduct)> SellProduct(int id, double quantity)
        {
            var product = await _repository.GetById(id);

            if (product is not null && product.Type != ProductTypes.RawMaterial)
            {
                var mappedProduct = _mapper.Map<ProductReadDto>(product);
                var unitaryValue = product.GetSellValue(quantity);
                product.RemoveQuantity(quantity);
                
                await CommitChangesAsync();

                return (unitaryValue, mappedProduct);
            }

            throw new ArgumentException($"Product with Id { id } does not exist.");
        }
    }
}