using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;

namespace PadariaTech.Services
{
    public class RecipeService : BaseService<Recipe, RecipeReadDto, RecipeCreateDto>
    {
        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper) : base(recipeRepository, mapper)
        {
        }

        public override int Register(RecipeCreateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public override bool Update(int id, RecipeCreateDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}