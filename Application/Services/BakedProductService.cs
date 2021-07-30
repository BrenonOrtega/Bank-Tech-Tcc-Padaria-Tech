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

        protected override async Task<BakedProduct> GetCreatedModel(BakedProductCreateDto dto)
        {
            var newBakedProduct = _mapper.Map<BakedProduct>(dto);
            var recipe = _recipeRepo
                .Get(recipe => recipe.Id == newBakedProduct.RecipeId && recipe.BakedProduct.Equals(null))
                .SingleOrDefault();

            if (recipe is not null)
            {
                newBakedProduct.Recipe = recipe;
                return newBakedProduct;
            }

            throw new ArgumentException("Another instance of BakedProduct already has this recipeId or does not exist.");
        }

        protected override async Task<BakedProduct> GetUpdatedModel(int id, BakedProductCreateDto dto)
        {
            var updatedBakedProduct = _mapper.Map<BakedProduct>(dto);
            updatedBakedProduct.Id = id;

            var originalBakedProduct = await _repository.GetById(id);
            var recipeAlreadyAssigned = _recipeRepo
                .Get(recipe => recipe.Id == updatedBakedProduct.RecipeId && recipe.BakedProduct.Id != id)
                .Any();

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