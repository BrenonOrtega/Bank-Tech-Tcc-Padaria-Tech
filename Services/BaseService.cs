using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PadariaTech.Domain.Interfaces;
using PadariaTech.Domain.Models;

namespace PadariaTech.Services
{
    public abstract class BaseService<T, TRead, TCreate> 
        where T : EntityBase 
        where TRead : new()
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper;

        public BaseService(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        ///<Returns>Registered model id</Returns>
        protected virtual int Register(T model)
        {
            if (model is not null)
            {
                _repository.Add(model);
            }

            return model.Id;
        }

        public void Update(int id, T model)
        {
            if (model is not null)
            {
                _repository.Update(id, model);
            }
        }

        public IEnumerable<TRead> GetAll()
        {
            var model = _repository
                .Get(x => true)
                .Select(x => _mapper.Map<TRead>(x))
                .ToList();

            return model;
        }

        public TRead GetById(int id)
        {
            var model = QueryById(id);

            if (model is null)
            {
                return new TRead();
            }

            var mappedModel = _mapper.Map<TRead>(model);
            return mappedModel;
        }

        public void Delete(int id)
        {
            var model = QueryById(id);

            if (model is not null)
            {
                _repository.Delete(model);
            }
        }

        protected T QueryById(int id)
        {
            var model = _repository
                .Get(prod => prod.Id.Equals(id))
                .FirstOrDefault();

            return model;
        }

        public Task<int> CommitChangesAsync() =>  
            _repository.SaveChanges();
    }
}