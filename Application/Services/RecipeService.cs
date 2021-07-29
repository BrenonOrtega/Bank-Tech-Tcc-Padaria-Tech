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
        private readonly IIngredientRepository _ingredientRepo;
        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper, IBakedProductRepository bakedProductRepository, IIngredientRepository ingredientRepository) 
        : base(recipeRepository, mapper)
        {
            _ingredientRepo = ingredientRepository;
        }

        protected override Recipe GetCreatedModel(RecipeCreateDto dto)
        {
            var modelRecipe = _mapper.Map<Recipe>(dto);
            return modelRecipe;
        }

        protected override Recipe GetUpdatedModel(int id, RecipeCreateDto dto)
        {
            throw new System.NotImplementedException();


        }
    }
}