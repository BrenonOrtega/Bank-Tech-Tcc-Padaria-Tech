using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using PadariaTech.Dtos.Read;
using PadariaTech.Models;

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

        private Ingredient QueryById(int id)
        {
            var ingredient = _ingredientRepository.Get(ingr => ingr.Id.Equals(id)).FirstOrDefault();

            return ingredient;
        }
    }
}