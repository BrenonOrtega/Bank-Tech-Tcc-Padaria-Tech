using AutoMapper;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;

namespace PadariaTech.Services
{
    public class ProductService : BaseService<Product, ProductReadDto, ProductCreateDto>
    {
        private readonly IProductRepository _productRepository;

        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper) 
            : base(productRepository, mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public int Register(ProductCreateDto modelDto)
        {
            throw new System.NotImplementedException();
        }
        
        public bool Update(ProductCreateDto modelDto)
        {
            throw new System.NotImplementedException();
        }
    }
}