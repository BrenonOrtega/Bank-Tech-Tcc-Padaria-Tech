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
        private readonly IProductRepository _productRepo;
        private readonly IRecipeRepository _recipeRepo;
        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
            : base(ingredientRepository, mapper)
        {
        }

        protected override Ingredient GetCreatedModel(IngredientCreateDto dto)
        {
            var newIngredient = _mapper.Map<Ingredient>(dto);

            newIngredient.Product = _productRepo
                .Get(product => product.Id == dto.IdProduct)
                .FirstOrDefault();

            newIngredient.Recipe = _recipeRepo
                .Get(recipe => recipe.Id == dto.IdRecipe)
                .FirstOrDefault();

            return newIngredient;
        }

        protected override Ingredient GetUpdatedModel(int id, IngredientCreateDto dto)
        {
            var updatedIngredient = _mapper.Map<Ingredient>(dto);

            var ingredient = _repository.Get(x => x.Id == id).FirstOrDefault();
            if (ingredient is not null)
            {
                if (ingredient.IdProduct != updatedIngredient.IdProduct)
                    updatedIngredient.Product = _productRepo.Get(x => x.Id == updatedIngredient.IdProduct).FirstOrDefault();
                
                if(ingredient.RecipeId != updatedIngredient.RecipeId)
                    updatedIngredient.Recipe = _recipeRepo.Get(x => x.Id == updatedIngredient.RecipeId).FirstOrDefault();
                
                return updatedIngredient;
            }

            throw new KeyNotFoundException("This Ingredient does Not Exist");
        }

        public IEnumerable<IngredientReadDto> GetByRecipe(int recipeId)
        {
            var ingredients = _repository.Get(ingredient => ingredient.Recipe.Id == recipeId).ToList();
            var mappedIngredients = _mapper.Map<IEnumerable<IngredientReadDto>>(ingredients);

            return mappedIngredients;
        }
    }
}