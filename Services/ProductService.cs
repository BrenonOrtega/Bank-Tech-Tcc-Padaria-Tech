using System;
using System.Linq;
using AutoMapper;
using PadariaTech.Dtos.Create;
using PadariaTech.Dtos.Read;
using PadariaTech.Models;

namespace PadariaTech.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void Register(ProductCreateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            if(product is null)
                _productRepository.Add(product);
        }

        public void Delete(ProductReadDto productDto)
        {
            var product = QueryById(productDto.Id);

            if(product is not null)
                _productRepository.Delete(product);
        }

        public ProductReadDto GetById(int id)
        {
             var product = QueryById(id);

            if(product is null)
                return new ProductReadDto();

            var mappedProduct = _mapper.Map<ProductReadDto>(product);
            return mappedProduct;
        }

        private Product QueryById(int id)
        {
            var product = _productRepository.Get(prod => prod.Id.Equals(id)).FirstOrDefault();
            
            return product;
        }
        

    }
}