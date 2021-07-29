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

        protected override Recipe GetCreatedModel(RecipeCreateDto dto)
        {
            throw new System.NotImplementedException();
        }

        protected override Recipe GetUpdatedModel(int id, RecipeCreateDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}