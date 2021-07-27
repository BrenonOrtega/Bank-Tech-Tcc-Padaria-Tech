using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PadariaTech.Dtos.Create;
using PadariaTech.Dtos.Read;
using PadariaTech.Models;

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
    }
}