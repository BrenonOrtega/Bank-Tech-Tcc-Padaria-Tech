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
        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper, IBakedProductRepository bakedProductRepository, IIngredientRepository ingredientRepository) 
        : base(recipeRepository, mapper)
        {
        }

        protected override Recipe GetCreatedModel(RecipeCreateDto dto)
        {
            var modelRecipe = _mapper.Map<Recipe>(dto);
            if(_repository.Get(x => true).Any(x => x.Name == modelRecipe.Name && x.Portion == modelRecipe.Portion))
            {
                throw new System.Exception("A similar recipe already exists.");
            }
            return modelRecipe;
        }

        protected override Recipe GetUpdatedModel(int id, RecipeCreateDto dto)
        {
            var updatedRecipe = _mapper.Map<Recipe>(dto);
            updatedRecipe.Id = id;
            var originalRecipe = _repository.GetById(id);

            if(originalRecipe is null) throw new KeyNotFoundException("the recipe to be updated does not exists");

            return updatedRecipe;
        }
    }
}