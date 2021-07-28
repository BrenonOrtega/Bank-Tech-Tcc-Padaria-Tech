using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;

namespace PadariaTech.Application.Services
{
    public class IngredientService
        : BaseService<Ingredient, IngredientReadDto, IngredientCreateDto>
    {
        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
            : base(ingredientRepository, mapper)
        {
        }

        public override async Task<int> Register(IngredientCreateDto dto)
        {
            return await CommitChangesAsync();
        }

        public override async Task<bool> Update(int id, IngredientCreateDto dto)
        {
            await CommitChangesAsync();
            throw new NotImplementedException();
        }

        public IEnumerable<IngredientReadDto> GetByRecipe(int recipeId)
        {
            var ingredients = _repository.Get(ingredient => ingredient.Recipe.Id == recipeId).ToList();
            var mappedIngredients = _mapper.Map<IEnumerable<IngredientReadDto>>(ingredients);
            
            return mappedIngredients;
        }
    }
}