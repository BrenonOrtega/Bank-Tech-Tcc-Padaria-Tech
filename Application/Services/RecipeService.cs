using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;

namespace PadariaTech.Application.Services
{
    public class RecipeService : BaseService<Recipe, RecipeReadDto, RecipeCreateDto>
    {
        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper) : base(recipeRepository, mapper)
        {
        }

        public override async Task<int> Register(RecipeCreateDto dto)
        {
            var model = _mapper.Map<Recipe>(dto);
            base.Register(model);
            await CommitChangesAsync();

            return model.Id;
        }

        public override Task<bool> Update(int id, RecipeCreateDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}