using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PadariaTech.Application.Dtos.Read;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;
using Microsoft.EntityFrameworkCore;
using PadariaTech.Domain.Enum;

namespace PadariaTech.Application.Services
{
    public class IngredientService
        : BaseService<Ingredient, IngredientReadDto, IngredientCreateDto>
    {
        private readonly IProductRepository _productRepo;
        private readonly IRecipeRepository _recipeRepo;
        public IngredientService(
            IIngredientRepository ingredientRepository,
            IProductRepository productRepo,
            IRecipeRepository RecipeRepo,
            IMapper mapper)
            : base(ingredientRepository, mapper)
        {
            _productRepo = productRepo;
            _recipeRepo = RecipeRepo;
        }

        protected async override Task<Ingredient> GetCreatedModel(IngredientCreateDto dto)
        {
            var newIngredient = _mapper.Map<Ingredient>(dto);
            var product = await _productRepo.GetById(dto.ProductId);
            var recipe = await _recipeRepo.GetById(dto.RecipeId);
     
            ThrowIfDoesNotExist(product, recipe, dto);
            ThrowIfDuplicated(product, recipe, dto);
            ThrowIfFinalProduct(product);

            return newIngredient;
        }

        private void ThrowIfFinalProduct(Product product)
        {
            if(product.Type == ProductTypes.FinalProduct)
                throw new ArgumentException("Cannot use a Final product as an ingredient");
        }

        protected async override Task<Ingredient> GetUpdatedModel(int id, IngredientCreateDto dto)
        {
            var updatedIngredient = _mapper.Map<Ingredient>(dto);
            var ingredient = await _repository.Get(x => x.Id == id).FirstOrDefaultAsync();

            if (ingredient is not null)
            {
                if (ingredient.ProductId != updatedIngredient.ProductId)
                    updatedIngredient.Product = await _productRepo.GetById(updatedIngredient.ProductId);
                else
                    updatedIngredient.Product = ingredient.Product;

                if (ingredient.RecipeId != updatedIngredient.RecipeId)
                    updatedIngredient.Recipe = await _recipeRepo.GetById(updatedIngredient.RecipeId);
                else
                    updatedIngredient.Recipe = ingredient.Recipe;

                return updatedIngredient;
            }

            throw new KeyNotFoundException("This Ingredient does Not Exist");
        }

        public IEnumerable<IngredientReadDto> GetByRecipe(int recipeId)
        {
            var ingredients = _repository.Get(ingredient => ingredient.Recipe.Id == recipeId).ToArray();
            var mappedIngredients = _mapper.Map<Ingredient[], List<IngredientReadDto>>(ingredients);
            
            return mappedIngredients;
        }

        private void ThrowIfDuplicated(Product product, Recipe recipe, IngredientCreateDto dto)
        {
            var duplicatedRecipe = recipe?.Ingredients.Any(i => i.Name == dto.Name && i.Quantity == dto.Quantity && i.ProductId == dto.ProductId);

            if((duplicatedRecipe) ?? false)
                throw new InvalidOperationException("There's a similar ingredient already assigned to recipe or product");
        }
        
        private void ThrowIfDoesNotExist(Product product, Recipe recipe, IngredientCreateDto dto)
        {
            var invalidProduct = product is null;
            var invalidRecipe = recipe is null;

            if (invalidProduct)
                throw new ArgumentException("Product does not exist");

            if(invalidRecipe)
                throw new ArgumentException("Recipe does not exist.");
        }
    }
}