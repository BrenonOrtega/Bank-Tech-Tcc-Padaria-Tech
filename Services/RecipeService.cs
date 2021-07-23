using System;
using System.Linq;
using AutoMapper;
using PadariaTech.Dtos.Create;
using PadariaTech.Dtos.Read;
using PadariaTech.Models;

namespace PadariaTech.Services
{
    public class RecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        private IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public void Register(RecipeCreateDto recipeDto)
        {
            var recipe = _mapper.Map<Recipe>(recipeDto);

            if(recipe is null)
                _recipeRepository.Add(recipe);
        }

        public void Delete(RecipeReadDto recipeDto)
        {
            var recipe = QueryById(recipeDto.Id);

            if(recipe is not null)
                _recipeRepository.Delete(recipe);
        }

        public RecipeReadDto GetById(int id)
        {
             var recipe = QueryById(id);

            if(recipe is null)
                return new RecipeReadDto();

            var mappedRecipe = _mapper.Map<RecipeReadDto>(recipe);
            return mappedRecipe;
        }

        private Recipe QueryById(int id)
        {
            var recipe = _recipeRepository.Get(prod => prod.Id.Equals(id)).FirstOrDefault();
            
            return recipe;
        }
        

    }
}