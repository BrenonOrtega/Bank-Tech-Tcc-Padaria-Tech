using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<ProductReadDto> GetAll()
        {
            var products = _productRepository
                .Get(x => true)
                .Select(x => _mapper.Map<ProductReadDto>(x))
                .ToList();

            return products;
        }

        public ProductReadDto GetById(int id)
        {
            var product = QueryById(id);

            if (product is null)
            {
                return new ProductReadDto();
            }

            var mappedProduct = _mapper.Map<ProductReadDto>(product);
            return mappedProduct;
        }

        ///<Returns>Registered product id</Returns>
        public int Register(ProductCreateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            if (product is null)
            {
                _productRepository.Add(product);
            }

            return product.Id;
        }

        public void Delete(int id)
        {
            var product = QueryById(id);

            if (product is not null)
            {
                _productRepository.Delete(product);
            }
        }

        private void Update(int id, ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            if (product is not null)
            {
                _productRepository.Update(id, product);
            }
        }

        private Product QueryById(int id)
        {
            var product = _productRepository.Get(prod => prod.Id.Equals(id)).FirstOrDefault();

            return product;
        }

        public Task<int> CommitChangesAsync()
        {
            return  _productRepository.SaveChanges();
        }
    }
}