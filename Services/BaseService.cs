using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PadariaTech.Interfaces;
using PadariaTech.Models.Base;

namespace PadariaTech.Services
{
    public abstract class BaseService<T, TRead, TCreate> where T : EntityBase  where TRead : new()
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper;

        public BaseService(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

                public IEnumerable<TRead> GetAll()
        {
            var products = _repository
                .Get(x => true)
                .Select(x => _mapper.Map<TRead>(x))
                .ToList();

            return products;
        }

        public TRead GetById(int id)
        {
            var product = QueryById(id);

            if (product is null)
            {
                return new TRead();
            }

            var mappedProduct = _mapper.Map<TRead>(product);
            return mappedProduct;
        }

        ///<Returns>Registered product id</Returns>
        public int Register(TCreate productDto)
        {
            var product = _mapper.Map<T>(productDto);

            if (product is not null)
            {
                _repository.Add(product);
            }

            return product.Id;
        }

        public void Delete(int id)
        {
            var product = QueryById(id);

            if (product is not null)
            {
                _repository.Delete(product);
            }
        }

        private void Update(int id, TCreate dto)
        {
            var product = _mapper.Map<T>(dto);

            if (product is not null)
            {
                _repository.Update(id, product);
            }
        }

        private T QueryById(int id)
        {
            var product = _repository.Get(prod => prod.Id.Equals(id)).FirstOrDefault();

            return product;
        }

        public Task<int> CommitChangesAsync()
        {
            return  _repository.SaveChanges();
        }
    }
}