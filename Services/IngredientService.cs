using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;

namespace PadariaTech.Services
{
    public class IngredientService
        : BaseService<Ingredient, IngredientReadDto, IngredientCreateDto>
    {
        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
            : base(ingredientRepository, mapper)
        {
        }

        public int Register(IngredientCreateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(IngredientCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}