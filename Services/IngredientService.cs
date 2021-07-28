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

        public override int Register(IngredientCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, IngredientCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}