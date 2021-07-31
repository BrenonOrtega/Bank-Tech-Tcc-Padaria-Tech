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

        public async Task BakeProduct(int id)
        {
            var product = await _repository.GetById(id);
            
            if(product is null)
                throw new KeyNotFoundException("Product does not exist.");

            try
            {
                product.Bake();
                await CommitChangesAsync();
            }
            catch
            {
                throw new Exception("could not bake product");
            }
        }

        protected override async Task<BakedProduct> GetCreatedModel(BakedProductCreateDto dto)
        {
            var newBakedProduct = _mapper.Map<BakedProduct>(dto);
            var exists = _repository
                .Get(prod => prod.Name == dto.Name && prod.Measure == dto.Measure && prod.Type == newBakedProduct.Type)
                .Any();
            var recipe = _recipeRepo
                .Get(recipe => recipe.Id == newBakedProduct.RecipeId && recipe.BakedProduct.Equals(null))
                .SingleOrDefault();

            if (recipe is null)
            {
            throw new ArgumentException("Another instance of BakedProduct already has this recipeId or does not exist.");
            }
            if(exists)
            {
                throw new ArgumentException("This BakedProduct already exists");
            }

            return await Task.FromResult(newBakedProduct);
        }

        protected override async Task<BakedProduct> GetUpdatedModel(int id, BakedProductCreateDto dto)
        {
            var updatedBakedProduct = _mapper.Map<BakedProduct>(dto);
            updatedBakedProduct.Id = id;

            var exists = _repository
                .Get(prod => prod.Name == dto.Name && prod.Measure == dto.Measure && prod.Type == updatedBakedProduct.Type)
                .Any();

            var originalBakedProduct = await _repository.GetById(id);
            var recipeAlreadyAssigned = _recipeRepo
                .Get(recipe => recipe.Id == updatedBakedProduct.RecipeId && recipe.BakedProduct.Id != id)
                .Any();

            if(exists)
            {
                throw new ArgumentException("This Baked Product already exists");
            }

            if (originalBakedProduct is null)
            {
                throw new KeyNotFoundException("This Baked Product does not exists");
            }

            if (recipeAlreadyAssigned)
            {
                throw new ArgumentException("Another instance of BakedProduct already has this recipeId");
            }

            return updatedBakedProduct;
        }
    }
}