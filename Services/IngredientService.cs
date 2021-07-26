using AutoMapper;
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
    }
}