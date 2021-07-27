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

        ///<Returns>Registered model id</Returns>
        public int Register(TCreate modelDto)
        {
            var model = _mapper.Map<T>(modelDto);

            if (model is not null)
            {
                _repository.Add(model);
            }

            return model.Id;
        }

        public void Delete(int id)
        {
            var model = QueryById(id);

            if (model is not null)
            {
                _repository.Delete(model);
            }
        }

        public void Update(int id, TCreate dto)
        {
            var model = _mapper.Map<T>(dto);

            if (model is not null)
            {
                _repository.Update(id, model);
            }
        }

        private T QueryById(int id)
        {
            var model = _repository.Get(prod => prod.Id.Equals(id)).FirstOrDefault();

            return model;
        }

        public Task<int> CommitChangesAsync()
        {
            return  _repository.SaveChanges();
        }
    }
}