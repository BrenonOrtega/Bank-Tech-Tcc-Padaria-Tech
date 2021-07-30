using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;
using System;

namespace PadariaTech.Application.Services
{
    public class RecipeService : BaseService<Recipe, RecipeReadDto, RecipeCreateDto>
    {
        public RecipeService(
            IRecipeRepository recipeRepository,
            IBakedProductRepository bakedProductRepository,
            IIngredientRepository ingredientRepository,
            IMapper mapper)
            : base(recipeRepository, mapper)
        {
        }

        protected override Recipe GetCreatedModel(RecipeCreateDto dto)
        {
            var recipeModel = _mapper.Map<Recipe>(dto);
            var exists = _repository.Get(x => x.Name == recipeModel.Name && x.Portion == recipeModel.Portion).Any();
            
            if (exists)
            {
                throw new Exception("A similar recipe already exists.");
            }

            return recipeModel;
        }

        protected override Recipe GetUpdatedModel(int id, RecipeCreateDto dto)
        {
            var updatedRecipe = _mapper.Map<Recipe>(dto);
            var recipeExists = _repository.Get(recipe => recipe.Id.Equals(id)).Any();
            updatedRecipe.Id = id;

            if (recipeExists) 
            {
                throw new KeyNotFoundException("the recipe to be updated does not exists");
            }
            
            return updatedRecipe;
        }
    }
}