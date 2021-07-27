using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using PadariaTech.Dtos.Read;
using PadariaTech.Models;
using PadariaTech.Dtos.Create;
using System.Threading.Tasks;

namespace PadariaTech.Services
{
    class IngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private IMapper _mapper;

        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public IEnumerable<IngredientReadDto> GetAll()
        {
            var ingredients = _ingredientRepository
                .Get(x => true)
                .Select(x => _mapper.Map<IngredientReadDto>(x))
                .ToList();
            return ingredients;
        }

        public IngredientReadDto GetById(int id)
        {
            var ingredient = QueryById(id);

            if(ingredient is null) return new IngredientReadDto();

            return _mapper.Map<IngredientReadDto>(ingredient);
        }

        public int Register(IngredientCreateDto ingredientCreateDto)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientCreateDto);

            if(ingredient is not null) _ingredientRepository.Add(ingredient);

            return ingredient.Id;
        }

        public void Delete(int id)
        {
            var ingredient = QueryById(id);

            if(ingredient is not null) _ingredientRepository.Delete(ingredient);
        }

        public void Update(int id, IngredientCreateDto ingredientCreateDto)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientCreateDto);
            
            if(ingredient is not null) _ingredientRepository.Update(id, ingredient);
        }

        private Ingredient QueryById(int id)
        {
            var ingredient = _ingredientRepository.Get(ingr => ingr.Id.Equals(id)).FirstOrDefault();

            return ingredient;
        }

        public Task<int> CommitChangesAsync()
        {
            return  _ingredientRepository.SaveChanges();
        }
    }
}