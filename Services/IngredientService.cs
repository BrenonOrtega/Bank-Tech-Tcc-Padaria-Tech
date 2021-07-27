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
    : BaseService<Ingredient, IngredientReadDto, IngredientCreateDto>
    {

        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper) 
            : base(ingredientRepository, mapper)
        {
        }
    }
}