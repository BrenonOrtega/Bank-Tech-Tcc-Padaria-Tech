using AutoMapper;
using PadariaTech.Domain.Models;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Application.Dtos.Read;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PadariaTech.Application.Services
{
    public class BakedProductService
        : BaseService<BakedProduct, BakedProductReadDto, BakedProductCreateDto>
    {
        private readonly IRecipeRepository _recipeRepo;
        public BakedProductService(
            IBakedProductRepository repository,
            IRecipeRepository recipeRepo,
            IMapper mapper)
            : base(repository, mapper)
        {
            _recipeRepo = recipeRepo;
        }

        protected override BakedProduct GetCreatedModel(BakedProductCreateDto dto)
        {
            var newBakedProduct = _mapper.Map<BakedProduct>(dto);
            newBakedProduct.Recipe = GetRecipeById(newBakedProduct.RecipeId);

            return newBakedProduct;
        }

        protected override BakedProduct GetUpdatedModel(int id, BakedProductCreateDto dto)
        {
            var updatedBakedProduct = _mapper.Map<BakedProduct>(dto);
            var originalBakedProduct = _repository.GetById(id);

            if (originalBakedProduct is not null && originalBakedProduct.RecipeId != updatedBakedProduct.RecipeId)
            {
                updatedBakedProduct.Recipe = GetRecipeById(updatedBakedProduct.Id);
                return updatedBakedProduct;
            }

            throw new KeyNotFoundException("This Baked Product does not exists");
        }

        public override BakedProductReadDto GetById(int id)
        {
            var mappedModel = base.GetById(id);
           
            var recipe = _recipeRepo.Get(recipe => recipe.BakedProduct.Id == id).FirstOrDefault();
            mappedModel.Recipe = _mapper.Map<BakedProductRecipeReadDto>(recipe);
            
            return mappedModel;
        }
    
        private Recipe GetRecipeById(int id) =>
            _recipeRepo.GetById(id) ?? throw new ArgumentException("Recipe does not exist");


        
    }
}