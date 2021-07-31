using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PadariaTech.Domain.Interfaces;
using PadariaTech.Domain.Models;

namespace PadariaTech.Application.Services
{
    public abstract class BaseService<TModel, TRead, TCreate>
        where TModel : EntityBase
        where TRead : new()
    {
        protected readonly IGenericRepository<TModel> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IGenericRepository<TModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        protected abstract Task<TModel> GetCreatedModel(TCreate dto);

        protected abstract Task<TModel> GetUpdatedModel(int id, TCreate dto);

        public virtual async Task<int> Register(TCreate dto)
        {
            var model = await GetCreatedModel(dto);

            if (model is not null)
            {
                _repository.Add(model);
            }
            await CommitChangesAsync();
            return model.Id;
        }

        public async Task Update(int id, TCreate dto)
        {
            var updatedModel = await GetUpdatedModel(id, dto);
            var model = await _repository.GetById(id);
            
            if (model is not null)
            {
                _repository.Update(id, model, updatedModel);
            }
            await CommitChangesAsync();
        }

        public virtual IEnumerable<TRead> GetAll()
        {
            var model = _repository
                .Get(x => true)
                .OfType<TModel>()
                .Select(x => _mapper.Map<TRead>(x))
                .ToList();

            return model;
        }

        public async virtual Task<TRead> GetById(int id)
        {
            var model = await _repository.GetById(id);

            if (model is null)
            {
                return new TRead();
            }

            var mappedModel = _mapper.Map<TRead>(model);
            return mappedModel;
        }

        public void Delete(int id)
        {
            var exists = _repository.Get(x => x.Id == id).Any();

            if (exists)
            {
                _repository.Delete(id);
            }
        }

        public async Task<int> CommitChangesAsync() =>
            await _repository.SaveChangesAsync();
    }
}