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
        private readonly IRecipeRepository _recipeRepository;

        private IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper) : base(recipeRepository, mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public int Register(RecipeCreateDto modelDto)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(RecipeCreateDto modelDto)
        {
            throw new System.NotImplementedException();
        }
    }
}